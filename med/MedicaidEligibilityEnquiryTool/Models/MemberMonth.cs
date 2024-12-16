using System;
using System.Collections.Generic;

namespace MedicaidEligibilityEnquiryTool.Models;

public partial class MemberMonth
{
    public int MemberMonthId { get; set; }

    public string MemberId { get; set; } = null!;

    public string? MedicareBeneficiaryId { get; set; }

    public DateOnly FirstOfCoverageMonth { get; set; }

    public DateOnly LastOfCoverageMonth { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string PhysicalAddressLine1 { get; set; } = null!;

    public string? PhysicalAddressLine2 { get; set; }

    public string PhysicalCity { get; set; } = null!;

    public string PhysicalState { get; set; } = null!;

    public string PhysicalPostalCode { get; set; } = null!;

    public string PhysicalCounty { get; set; } = null!;

    public string? MemberRegion { get; set; }

    public string SubscriberPhysicalCounty { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? SocialSecurityNumber { get; set; }

    public string MailingAddressLine1 { get; set; } = null!;

    public string? MailingAddressLine2 { get; set; }

    public string MailingCity { get; set; } = null!;

    public string MailingState { get; set; } = null!;

    public string MailingPostalCode { get; set; } = null!;

    public string MailingCounty { get; set; } = null!;

    public string MedicalPrimaryEnrollmentId { get; set; } = null!;

    public string MedicalPrimaryGroupNumber { get; set; } = null!;

    public string MedicalPrimaryGroupName { get; set; } = null!;

    public string MedicalPrimaryGroupSize { get; set; } = null!;

    public string MedicalPrimaryGroupSizeActual { get; set; } = null!;

    public string MedicalPrimaryGroupAddressCounty { get; set; } = null!;

    public string MedicalPrimaryGroupAddressPostalCode { get; set; } = null!;

    public string MedicalPrimaryEnrollType { get; set; } = null!;

    public string? MedicalPrimaryUphbenefitCode { get; set; }

    public string MedicalPrimarySegType { get; set; } = null!;

    public string MedicalPrimaryHiosPlanId { get; set; } = null!;

    public string MedicalPrimaryPolicyNumber { get; set; } = null!;

    public string MedicalPrimaryPolicyNumberActual { get; set; } = null!;

    public decimal? MedicalPrimaryPremiumAmount { get; set; }

    public string MedicalPrimaryProgramName { get; set; } = null!;

    public string MedicalPrimaryProgramId { get; set; } = null!;

    public string MemberInternalId { get; set; } = null!;

    public string SubscriberInternalId { get; set; } = null!;

    public string MedicalPrimaryOrgPolicyId { get; set; } = null!;

    public string MedicalPrimaryRateId { get; set; } = null!;

    public string MedicalPrimaryPlanId { get; set; } = null!;

    public string MedicalPrimaryPlanType { get; set; } = null!;

    public string MedicalPrimaryPlanName { get; set; } = null!;

    public string MedicalPrimaryLineOfBusiness { get; set; } = null!;

    public string MedicalPrimaryEligibleOrgId { get; set; } = null!;

    public string MedicalPrimaryPosPlan { get; set; } = null!;

    public string MedicalPrimaryProductType { get; set; } = null!;

    public string MedicalPrimaryProgramPolicyId { get; set; } = null!;

    public string MedicalPrimaryProgramPolicyDescription { get; set; } = null!;

    public string MedicalPrimaryFinancialEntity { get; set; } = null!;

    public string MedicalPrimaryFinancialEntityShort { get; set; } = null!;

    public string PcpGroupAffiliationId { get; set; } = null!;

    public string PcpGroupAffiliateId { get; set; } = null!;

    public string PcpProviderId { get; set; } = null!;

    public string PcpNationalProviderIdentifier { get; set; } = null!;

    public string PcpName { get; set; } = null!;

    public string GroupId { get; set; } = null!;

    public string GroupNationalProviderIdentifier { get; set; } = null!;

    public string GroupTaxIdentificationNumber { get; set; } = null!;

    public string GroupName { get; set; } = null!;

    public string? MedicalPrimaryPcpCapitationContractId { get; set; }

    public string? MedicalPrimaryPcpCapitationId { get; set; }

    public int? MedicalPrimaryPcpCapitationTermId { get; set; }

    public string? MedicalPrimaryPcpCapitationContractName { get; set; }

    public string? MedicalPrimaryPcpCapitationDescription { get; set; }

    public string? MedicalPrimaryPcpCapitationTermDescription { get; set; }

    public decimal? MedicalPrimaryPcpCapitationAmount { get; set; }

    public string? MedicalSecondaryEnrollmentId { get; set; }

    public string? MedicalSecondaryGroupNumber { get; set; }

    public string? MedicalSecondaryGroupName { get; set; }

    public string? MedicalSecondaryGroupSize { get; set; }

    public string? MedicalSecondaryGroupSizeActual { get; set; }

    public string? MedicalSecondaryGroupAddressCounty { get; set; }

    public string? MedicalSecondaryGroupAddressPostalCode { get; set; }

    public string? MedicalSecondaryEnrollType { get; set; }

    public string? MedicalSecondarySegType { get; set; }

    public string? MedicalSecondaryHiosPlanId { get; set; }

    public string? MedicalSecondaryPolicyNumber { get; set; }

    public string? MedicalSecondaryPolicyNumberActual { get; set; }

    public string? MedicalSecondaryProgramName { get; set; }

    public string? MedicalSecondaryProgramId { get; set; }

    public string? MedicalSecondaryOrgPolicyId { get; set; }

    public string? MedicalSecondaryRateId { get; set; }

    public string? MedicalSecondaryPlanId { get; set; }

    public string? MedicalSecondaryPlanType { get; set; }

    public string? MedicalSecondaryPlanName { get; set; }

    public string? MedicalSecondaryLineOfBusiness { get; set; }

    public string? MedicalSecondaryEligibleOrgId { get; set; }

    public string? MedicalSecondaryPosPlan { get; set; }

    public string? MedicalSecondaryProductType { get; set; }

    public string? MedicalSecondaryProgramPolicyId { get; set; }

    public string? MedicalSecondaryProgramPolicyDescription { get; set; }

    public string? MedicalSecondaryFinancialEntity { get; set; }

    public string? MedicalSecondaryFinancialEntityShort { get; set; }

    public string? DentalPrimaryEnrollmentId { get; set; }

    public string? DentalPrimaryGroupNumber { get; set; }

    public string? DentalPrimaryGroupName { get; set; }

    public string? DentalPrimaryGroupSize { get; set; }

    public string? DentalPrimaryGroupSizeActual { get; set; }

    public string? DentalPrimaryGroupAddressCounty { get; set; }

    public string? DentalPrimaryGroupAddressPostalCode { get; set; }

    public string? DentalPrimaryEnrollType { get; set; }

    public string? DentalPrimarySegType { get; set; }

    public string? DentalPrimaryHiosPlanId { get; set; }

    public string? DentalPrimaryPolicyNumber { get; set; }

    public string? DentalPrimaryPolicyNumberActual { get; set; }

    public decimal? DentalPrimaryPremiumAmount { get; set; }

    public string? DentalPrimaryProgramName { get; set; }

    public string? DentalPrimaryProgramId { get; set; }

    public string? DentalPrimaryOrgPolicyId { get; set; }

    public string? DentalPrimaryRateId { get; set; }

    public string? DentalPrimaryPlanId { get; set; }

    public string? DentalPrimaryPlanType { get; set; }

    public string? DentalPrimaryPlanName { get; set; }

    public string? DentalPrimaryLineOfBusiness { get; set; }

    public string? DentalPrimaryEligibleOrgId { get; set; }

    public string? DentalPrimaryPosPlan { get; set; }

    public string? DentalPrimaryProductType { get; set; }

    public string? DentalPrimaryProgramPolicyId { get; set; }

    public string? DentalPrimaryProgramPolicyDescription { get; set; }

    public string? DentalPrimaryFinancialEntity { get; set; }

    public string? DentalPrimaryFinancialEntityShort { get; set; }

    public string? PrescriptionPrimaryEnrollmentId { get; set; }

    public string? PrescriptionPrimaryGroupNumber { get; set; }

    public string? PrescriptionPrimaryGroupName { get; set; }

    public string? PrescriptionPrimaryGroupSize { get; set; }

    public string? PrescriptionPrimaryGroupSizeActual { get; set; }

    public string? PrescriptionPrimaryGroupAddressCounty { get; set; }

    public string? PrescriptionPrimaryGroupAddressPostalCode { get; set; }

    public string? PrescriptionPrimaryEnrollType { get; set; }

    public string? PrescriptionPrimarySegType { get; set; }

    public string? PrescriptionPrimaryHiosPlanId { get; set; }

    public string? PrescriptionPrimaryPolicyNumber { get; set; }

    public string? PrescriptionPrimaryPolicyNumberActual { get; set; }

    public decimal? PrescriptionPrimaryPremiumAmount { get; set; }

    public string? PrescriptionPrimaryProgramName { get; set; }

    public string? PrescriptionPrimaryProgramId { get; set; }

    public string? PrescriptionPrimaryOrgPolicyId { get; set; }

    public string? PrescriptionPrimaryRateId { get; set; }

    public string? PrescriptionPrimaryPlanId { get; set; }

    public string? PrescriptionPrimaryPlanType { get; set; }

    public string? PrescriptionPrimaryPlanName { get; set; }

    public string? PrescriptionPrimaryLineOfBusiness { get; set; }

    public string? PrescriptionPrimaryEligibleOrgId { get; set; }

    public string? PrescriptionPrimaryPosPlan { get; set; }

    public string? PrescriptionPrimaryProductType { get; set; }

    public string? PrescriptionPrimaryProgramPolicyId { get; set; }

    public string? PrescriptionPrimaryProgramPolicyDescription { get; set; }

    public string? PrescriptionPrimaryFinancialEntity { get; set; }

    public string? PrescriptionPrimaryFinancialEntityShort { get; set; }
}
