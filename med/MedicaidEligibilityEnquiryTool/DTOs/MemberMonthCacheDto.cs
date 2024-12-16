using Microsoft.EntityFrameworkCore;

namespace MedicaidEligibilityEnquiryTool.DTOs
{
    [Keyless]
    public class MemberMonthCacheDto
    {
        public string CustomerId { get; set; } = null!;

        public string? MedicareBeneficiaryId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? SocialSecurityNumber { get; set; }

        public string? SubscriberRelationship { get; set; }

        public DateOnly? AsOfDate { get; set; }

        public string? PayerName { get; set; }

        public bool IsMedicaid { get; set; }
    }
}