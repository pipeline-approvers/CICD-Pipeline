using Microsoft.EntityFrameworkCore;

namespace MedicaidEligibilityEnquiryTool.DTOs
{
    [Keyless]
    public class MemberMonthDto
    {
        public int MemberMonthId { get; set; }
        public string MemberId { get; set; } = null!;
        public string MedicalPrimaryEnrollmentId { get; set; } = null!;
        public string? MedicareBeneficiaryId { get; set; }
        public string PhysicalAddressLine1 { get; set; } = null!;
        public string? PhysicalAddressLine2 { get; set; }
        public string PhysicalCity { get; set; } = null!;
        public string PhysicalState { get; set; } = null!;
        public string PhysicalPostalCode { get; set; } = null!;
        public string PhysicalCounty { get; set; } = null!;
        public DateOnly FirstOfCoverageMonth { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
