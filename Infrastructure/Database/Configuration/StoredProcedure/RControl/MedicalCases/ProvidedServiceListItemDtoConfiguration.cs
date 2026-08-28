using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.MedicalCases;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.MedicalCases;

public class ProvidedServiceListItemDtoConfiguration : IEntityTypeConfiguration<ProvidedServiceListItemDto>
{
    public void Configure(EntityTypeBuilder<ProvidedServiceListItemDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ProvidedServiceUid).HasColumnName("uid");
        builder.Property(prop => prop.ServiceCode).HasColumnName("service_code");
        builder.Property(prop => prop.Service).HasColumnName("service").IsRequired(false);
        builder.Property(prop => prop.MedicalInterventionType).HasColumnName("vid_vme").IsRequired(false);
        builder.Property(prop => prop.MedicalProfileCode).HasColumnName("medical_profile_code");
        builder.Property(prop => prop.MedicalProfile).HasColumnName("medical_profile");
        builder.Property(prop => prop.PhysicianSpecialtyCode).HasColumnName("physician_specialty_code");
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("physician_specialty");
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.ServiceStartDate).HasColumnName("date_in");
        builder.Property(prop => prop.ServiceEndDate).HasColumnName("date_out");
        builder.Property(prop => prop.Diagnosis).HasColumnName("ds");
        builder.Property(prop => prop.ServiceQuantity).HasColumnName("kol_usl");
        builder.Property(prop => prop.UnitRate).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.AmountBilled).HasColumnName("sumv_usl");
        builder.Property(prop => prop.InternalComment).HasColumnName("comentu").IsRequired(false);
    }
}
