using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.MedicalCases;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.MedicalCases;

public class InsuranceDtoConfiguration : IEntityTypeConfiguration<InsuranceDto>
{
    public void Configure(EntityTypeBuilder<InsuranceDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InsuranceCompanyCode).HasColumnName("insurance_company_code").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyName).HasColumnName("insurance_company_name").IsRequired(false);
        builder.Property(prop => prop.OGRN).HasColumnName("OGRN").IsRequired(false);
        builder.Property(prop => prop.OKATO).HasColumnName("OKATO").IsRequired(false);
        builder.Property(prop => prop.InsurancePolicyUnifiedNumber).HasColumnName("insurance_policy_unified_number").IsRequired(false);
        builder.Property(prop => prop.InsurancePolicySeries).HasColumnName("insurance_policy_series").IsRequired(false);
        builder.Property(prop => prop.InsurancePolicyNumber).HasColumnName("insurance_policy_number");
        builder.Property(prop => prop.InsurancePolicyTypeCode).HasColumnName("insurance_policy_type_code");
        builder.Property(prop => prop.InsurancePolicyTypeName).HasColumnName("insurance_policy_type_name");
    }

}