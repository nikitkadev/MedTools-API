using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.MedicalCases;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.MedicalCases;

public class ReferralDtoConfiguration : IEntityTypeConfiguration<ReferralDto>
{
    public void Configure(EntityTypeBuilder<ReferralDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ReferralUid).HasColumnName("uid");
        builder.Property(prop => prop.ReferralDate).HasColumnName("napr_date");
        builder.Property(prop => prop.ReferredToMoCode).HasColumnName("napr_mo").IsRequired(false);
        builder.Property(prop => prop.ReferralTypeCode).HasColumnName("referral_type_code");
        builder.Property(prop => prop.ReferralType).HasColumnName("referral_type");
        builder.Property(prop => prop.DiagnosticMethodCode).HasColumnName("diagnostic_method_code").IsRequired(false);
        builder.Property(prop => prop.DiagnosticMethod).HasColumnName("diagnostic_method").IsRequired(false);
        builder.Property(prop => prop.ReferredServiceCode).HasColumnName("referred_service_code").IsRequired(false);
        builder.Property(prop => prop.ReferredService).HasColumnName("referred_service").IsRequired(false);
    }
}
