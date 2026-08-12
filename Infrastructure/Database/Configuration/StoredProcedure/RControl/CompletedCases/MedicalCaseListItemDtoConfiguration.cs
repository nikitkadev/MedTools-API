using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.CompletedCases;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.CompletedCases;

public class MedicalCaseListItemDtoConfiguration : IEntityTypeConfiguration<MedicalCaseListItemDto>
{
    public void Configure(EntityTypeBuilder<MedicalCaseListItemDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("uid");
        builder.Property(prop => prop.MedicalProfile).HasColumnName("profil").IsRequired(false);
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("prvs");
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_2");
        builder.Property(prop => prop.PrimaryDiagnosis).HasColumnName("ds1");
        builder.Property(prop => prop.PaidUnits).HasColumnName("ed_col").IsRequired(false);
        builder.Property(prop => prop.UnitRate).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.AmountBilled).HasColumnName("sum_m");
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("sump").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_sump").IsRequired(false);
    }
}
