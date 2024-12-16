using System;
using System.Collections.Generic;
using MedicaidEligibilityEnquiryTool.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicaidEligibilityEnquiryTool.Models;

public partial class PhpEdwContext : DbContext
{
    public PhpEdwContext()
    {
    }

    public PhpEdwContext(DbContextOptions<PhpEdwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MemberMonth> MemberMonths { get; set; }

    public virtual DbSet<MemberMonthCache> MemberMonthCaches { get; set; }

    public virtual DbSet<UserDetailsMet> UserDetailsMets { get; set; }

    public virtual DbSet<MemberMonthDto> MemeberMonthDtos { get; set; }
    public virtual DbSet<MemberMonthCacheDto> MemberMonthCacheDtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_Pref_CP1_CI_AS");

        modelBuilder.Entity<MemberMonth>(entity =>
        {
            entity.HasKey(e => e.MemberMonthId)
                .HasName("PK_nltx_MemberMonth")
                .IsClustered(false);

            entity.ToTable("MemberMonth", "nltx");

            entity.Property(e => e.DentalPrimaryEligibleOrgId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryEnrollType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DentalPrimaryEnrollmentId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryFinancialEntity)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryFinancialEntityShort)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DentalPrimaryGroupAddressCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryGroupAddressPostalCode)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DentalPrimaryGroupName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryGroupNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryGroupSize)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryGroupSizeActual)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryHiosPlanId)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryLineOfBusiness)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryOrgPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPlanId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPlanName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPlanType)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPolicyNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPolicyNumberActual)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPosPlan)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryPremiumAmount).HasColumnType("decimal(14, 4)");
            entity.Property(e => e.DentalPrimaryProductType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryProgramId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryProgramName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryProgramPolicyDescription)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryProgramPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimaryRateId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.DentalPrimarySegType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GroupId)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.GroupName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.GroupNationalProviderIdentifier)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.GroupTaxIdentificationNumber)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MailingAddressLine1)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MailingAddressLine2)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MailingCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MailingCounty)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MailingPostalCode)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.MailingState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalPrimaryEligibleOrgId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryEnrollType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalPrimaryEnrollmentId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryFinancialEntity)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryFinancialEntityShort)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalPrimaryGroupAddressCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryGroupAddressPostalCode)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalPrimaryGroupName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryGroupNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryGroupSize)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryGroupSizeActual)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryHiosPlanId)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryLineOfBusiness)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryOrgPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPcpCapitationAmount).HasColumnType("decimal(14, 4)");
            entity.Property(e => e.MedicalPrimaryPcpCapitationContractId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPcpCapitationContractName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPcpCapitationDescription)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPcpCapitationId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPcpCapitationTermDescription)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPlanId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPlanName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPlanType)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPolicyNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPolicyNumberActual)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPosPlan)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryPremiumAmount).HasColumnType("decimal(14, 4)");
            entity.Property(e => e.MedicalPrimaryProductType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryProgramId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryProgramName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryProgramPolicyDescription)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryProgramPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryRateId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimarySegType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.MedicalPrimaryUphbenefitCode)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("MedicalPrimaryUPHBenefitCode");
            entity.Property(e => e.MedicalSecondaryEligibleOrgId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryEnrollType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalSecondaryEnrollmentId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryFinancialEntity)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryFinancialEntityShort)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalSecondaryGroupAddressCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryGroupAddressPostalCode)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MedicalSecondaryGroupName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryGroupNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryGroupSize)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryGroupSizeActual)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryHiosPlanId)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryLineOfBusiness)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryOrgPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryPlanId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryPlanName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryPlanType)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryPolicyNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryPolicyNumberActual)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryPosPlan)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryProductType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryProgramId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryProgramName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryProgramPolicyDescription)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryProgramPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondaryRateId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MedicalSecondarySegType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.MedicareBeneficiaryId)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.MemberInternalId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MemberRegion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PcpGroupAffiliateId)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PcpGroupAffiliationId)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PcpName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PcpNationalProviderIdentifier)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PcpProviderId)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PhysicalAddressLine1)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PhysicalAddressLine2)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PhysicalCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhysicalCounty)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PhysicalPostalCode)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.PhysicalState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PrescriptionPrimaryEligibleOrgId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryEnrollType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PrescriptionPrimaryEnrollmentId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryFinancialEntity)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryFinancialEntityShort)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PrescriptionPrimaryGroupAddressCounty)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryGroupAddressPostalCode)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PrescriptionPrimaryGroupName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryGroupNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryGroupSize)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryGroupSizeActual)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryHiosPlanId)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryLineOfBusiness)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryOrgPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPlanId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPlanName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPlanType)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPolicyNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPolicyNumberActual)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPosPlan)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryPremiumAmount).HasColumnType("decimal(14, 4)");
            entity.Property(e => e.PrescriptionPrimaryProductType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryProgramId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryProgramName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryProgramPolicyDescription)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryProgramPolicyId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimaryRateId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PrescriptionPrimarySegType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SubscriberInternalId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SubscriberPhysicalCounty)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MemberMonthCache>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__MemberMo__A4AE64D8C1C8A4EA");

            entity.ToTable("MemberMonthCache");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MedicareBeneficiaryId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PayerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubscriberRelationship)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserDetailsMet>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserDetails_MET");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
