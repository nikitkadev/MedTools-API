using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.MedicalCases;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.MedicalCases;

public class HighTechMedicalCareDtoConfiguration : IEntityTypeConfiguration<HighTechMedicalCareDto>
{
    public void Configure(EntityTypeBuilder<HighTechMedicalCareDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.HighTechCareTypeCode).HasColumnName("high_tech_care_type_code").IsRequired(false);
        builder.Property(prop => prop.HighTechCareMethodCode).HasColumnName("high_tech_care_method_code").IsRequired(false);
        builder.Property(prop => prop.VoucherIssueDate).HasColumnName("tal_d").IsRequired(false);
        builder.Property(prop => prop.VoucherNumber).HasColumnName("tal_num").IsRequired(false);
        builder.Property(prop => prop.PlannedAdmissionDate).HasColumnName("tal_p").IsRequired(false);
    }
}