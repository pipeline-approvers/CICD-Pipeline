using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MedicaidEligibilityEnquiryTool.Models;
using MedicaidEligibilityEnquiryTool.DTOs;
using Microsoft.Data.SqlClient;

namespace MedicaidEligibilityEnquiryTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PhpEdwContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PatientController> _logger;
        private readonly IMemoryCache _memoryCache;
        public PatientController(PhpEdwContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory,
            ILogger<PatientController> logger, IMemoryCache memoryCache)
        {
            dbContext = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberMonth(
        [FromQuery] string userName,
        [FromQuery] string? medicareBeneficiaryId = null,
        [FromQuery] string? socialSecurityNumber = null,
        [FromQuery] string? firstName = null,
        [FromQuery] string? lastName = null,
        [FromQuery] bool isMedicaid = false)
        {
            try
            {
                // Validate that at least one of the mandatory parameters is provided
                if (string.IsNullOrEmpty(medicareBeneficiaryId) && string.IsNullOrEmpty(socialSecurityNumber))
                {
                    return BadRequest("Either 'medicareBeneficiaryId' or 'socialSecurityNumber' is required.");
                }

                // Create a unique cache key
                string cacheKey = $"{medicareBeneficiaryId}-{socialSecurityNumber}-{isMedicaid}";

                if (_memoryCache.TryGetValue(cacheKey, out var cachedResponse))
                {                
                    return Ok(cachedResponse);
                }

                //Get user Details from the UserDetails_MET table
                UserDetailsMet? user = await dbContext.UserDetailsMets.FirstOrDefaultAsync(x => x.UserName == userName);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Call stored procedure with parameters
                var parameters = new[]
                {
                new SqlParameter("@medicareBeneficiaryId", medicareBeneficiaryId ?? (object)DBNull.Value),
                new SqlParameter("@socialSecurityNumber", socialSecurityNumber ?? (object)DBNull.Value)
                };

                var memberMonth = await dbContext.MemeberMonthDtos
                    .FromSqlRaw("EXEC nltx.spfetchMemberMonthRow @medicareBeneficiaryId, @socialSecurityNumber", parameters)
                    .ToListAsync();

                // Check if any results were returned and map to DTO
                var memberMonthDto = memberMonth.Select(e => new MemberMonthDto
                {
                    MemberMonthId = e.MemberMonthId,
                    MemberId = e.MemberId,
                    MedicalPrimaryEnrollmentId = e.MedicalPrimaryEnrollmentId,
                    MedicareBeneficiaryId = e.MedicareBeneficiaryId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhysicalAddressLine1 = e.PhysicalAddressLine1,
                    PhysicalAddressLine2 = e.PhysicalAddressLine2,
                    PhysicalCity = e.PhysicalCity,
                    PhysicalState = e.PhysicalState,
                    PhysicalPostalCode = e.PhysicalPostalCode,
                    PhysicalCounty = e.PhysicalCounty,
                    FirstOfCoverageMonth = e.FirstOfCoverageMonth
                }).FirstOrDefault();

                // Return the result or a 404 if not found
                if (memberMonthDto != null && isMedicaid == false)
                {
                    user.ApiCount++;
                    await dbContext.SaveChangesAsync();
                    _memoryCache.Set(cacheKey, memberMonthDto, TimeSpan.FromMinutes(30));
                    return Ok(memberMonthDto);
                }

                // If not found, check MemberMonthCache table
                var cachedMemberMonth = await dbContext.MemberMonthCacheDtos
                    .FromSqlRaw("EXEC dbo.spFetchMemberMonthCache @medicareBeneficiaryId, @socialSecurityNumber", parameters)
                    .ToListAsync();

                if (cachedMemberMonth != null && cachedMemberMonth.Any())
                {
                    var cachedDto = cachedMemberMonth.Select(e => new MemberMonthCacheDto
                    {
                        // Map the necessary fields from cached data
                        CustomerId = e.CustomerId,
                        MedicareBeneficiaryId = e.MedicareBeneficiaryId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        SocialSecurityNumber = e.SocialSecurityNumber,
                        SubscriberRelationship = e.SubscriberRelationship,
                        AsOfDate = e.AsOfDate,
                        PayerName = e.PayerName,
                        IsMedicaid = e.IsMedicaid
                    }).FirstOrDefault();

                    // Return cached response
                    return Ok(cachedDto);
                }

                // If not found, call Availity API
                var client = _httpClientFactory.CreateClient();
                var cmsConfig = _configuration.GetSection("CMS");

                // Get Auth Token
                var authUrl = cmsConfig["AuthUrl"];
                var clientId = cmsConfig["client_id"];
                var clientSecret = cmsConfig["client_secret"];
                var scope = cmsConfig["scope"];

                // Check for null values 
                if (string.IsNullOrEmpty(authUrl) || string.IsNullOrEmpty(clientId) ||
                    string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(scope))
                {
                    throw new InvalidOperationException("One or more configuration values are missing.");
                }

                var tokenResponse = await client.PostAsync(authUrl, new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("scope", scope)
                }));

                tokenResponse.EnsureSuccessStatusCode();
                var tokenResponseBody = await tokenResponse.Content.ReadAsStringAsync();
                dynamic tokenJson = JsonConvert.DeserializeObject(tokenResponseBody);
                var accessToken = tokenJson.access_token;

                // Get Coverage
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", (string)accessToken);
                var requestUrl = $"{cmsConfig["CoverageUrl"]}?memberId={medicareBeneficiaryId}&providerLastName={lastName}&providerFirstName={firstName}&providerSSN={socialSecurityNumber}";

                var coverageResponse = await client.GetAsync(requestUrl);

                if (coverageResponse.IsSuccessStatusCode)
                {
                    var coverageResponseBody = await coverageResponse.Content.ReadAsStringAsync();
                    var coverageJson = JsonConvert.DeserializeObject<JObject>(coverageResponseBody);

                    // Check if coverages array is empty
                    var coverages = coverageJson["coverages"] as JArray;
                    if (coverages == null || !coverages.Any())
                    {
                        return NotFound("No coverage data found in CMS.");
                    }

                    // Extract the first item (or handle as needed)
                    var coverageItem = coverages.First() as JObject;
                    if (coverageItem == null)
                    {
                        return NotFound("No coverage data found in CMS.");
                    }

                    // Extract and convert AsOfDate to DateTime
                    DateTime? asOfDate = null;
                    if (DateTime.TryParse(coverageItem["asOfDate"]?.ToString(), out var parsedDate))
                    {
                        asOfDate = parsedDate;
                    }

                    // Create the response object with required fields
                    var result = new
                    {
                        CustomerId = coverageItem["customerId"]?.ToString(),
                        FirstName = coverageItem["patient"]?["firstName"]?.ToString(),
                        LastName = coverageItem["patient"]?["lastName"]?.ToString(),
                        SubscriberRelationship = coverageItem["patient"]?["subscriberRelationship"]?.ToString(),
                        AsOfDate = asOfDate,
                        PayerName = coverageItem["payer"]?["name"]?.ToString(),
                        isMedicaid = true
                    };

                    // Save the response to MemberMonthCache using a stored procedure
                    await dbContext.Database.ExecuteSqlRawAsync("EXEC dbo.spSaveMemberMonthCache @CustomerId, @MedicareBeneficiaryId, @FirstName, @LastName, @SocialSecurityNumber, @SubscriberRelationship, @AsOfDate, @PayerName, @IsMedicaid",
                        new SqlParameter("@CustomerId", result.CustomerId),
                        new SqlParameter("@MedicareBeneficiaryId", medicareBeneficiaryId ?? (object)DBNull.Value),
                        new SqlParameter("@FirstName", result.FirstName),
                        new SqlParameter("@LastName", result.LastName),
                        new SqlParameter("@SocialSecurityNumber", socialSecurityNumber ?? (object)DBNull.Value),
                        new SqlParameter("@SubscriberRelationship", result.SubscriberRelationship),
                        new SqlParameter("@AsOfDate", (object)asOfDate ?? DBNull.Value),
                        new SqlParameter("@PayerName", result.PayerName),
                        new SqlParameter("@IsMedicaid", result.isMedicaid));

                    // Update the API count after successful response from CMS
                    user.ApiCount++;
                    await dbContext.SaveChangesAsync();

                    // Cache the result for faster access next time
                    _memoryCache.Set(cacheKey, result, TimeSpan.FromMinutes(30));
                    return Ok(result);
                }

                return NotFound("Member not found in CMS.");
            }
            catch (Exception ex)
            {
                // Log the exception using Serilog
                _logger.LogError(ex, "An error occurred in GetMemberMonth while processing memberId: {MemberId} and SSN: {SSN}", medicareBeneficiaryId, socialSecurityNumber);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpGet("GetUserApiCallCount")]
        public async Task<ActionResult<Object>> GetUserApiCallCount([FromQuery] string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("User can not be null or empty");
            }
            //Get user Details from the UserDetails_MET table
            var user = await dbContext.UserDetailsMets.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var response = new
            {
                apiCount = user.ApiCount,
                apiMaxThresholdLimit = user.ApiThresholdLimit
            };

            return Ok(response);

        }
    }
}
