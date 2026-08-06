using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Categories.MedicalCase;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories.MedicalCase;

public class CompletedCaseDetailsDtoConfiguration : IEntityTypeConfiguration<CompletedCaseDetailsDto>
{
    public void Configure(EntityTypeBuilder<CompletedCaseDetailsDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("lpu");
        builder.Property(prop => prop.ReferringMedicalOrganizationCode).HasColumnName("npr_mo").IsRequired(false);
        builder.Property(prop => prop.ReferralDate).HasColumnName("npr_date").IsRequired(false);
        builder.Property(prop => prop.CareConditions).HasColumnName("usl_ok");
        builder.Property(prop => prop.MedicalCareType).HasColumnName("vidpom");
        builder.Property(prop => prop.PaymentMethodCode).HasColumnName("idsp");
        builder.Property(prop => prop.MedicalCareForm).HasColumnName("for_pom");
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_z_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_z_2");
        builder.Property(prop => prop.HospitalizationDuration).HasColumnName("kd_z").IsRequired(false);
        builder.Property(prop => prop.HospitalizationOutcome).HasColumnName("rslt");
        builder.Property(prop => prop.IsIntrahospitalTransfer).HasColumnName("vb_p").IsRequired(false);
        builder.Property(prop => prop.ScreeningResult).HasColumnName("rslt_d").IsRequired(false);
        builder.Property(prop => prop.IsRefusal).HasColumnName("p_otk").IsRequired(false);
        builder.Property(prop => prop.IsMobileTeam).HasColumnName("vbr").IsRequired(false);
        builder.Property(prop => prop.DiseaseOutcome).HasColumnName("ishod");
    }
}