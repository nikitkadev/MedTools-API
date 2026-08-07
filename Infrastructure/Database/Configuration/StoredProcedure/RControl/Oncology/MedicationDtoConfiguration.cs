using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Oncology;

public class MedicationDtoConfiguration : IEntityTypeConfiguration<MedicationDto>
{
    public void Configure(EntityTypeBuilder<MedicationDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicamentUid).HasColumnName("uid");
        builder.Property(prop => prop.DrugIdentifier).HasColumnName("regnum");
        builder.Property(prop => prop.DrugExtendedIdentifier).HasColumnName("regnum_dop").IsRequired(false);
        builder.Property(prop => prop.TherapyRegimenCode).HasColumnName("code_sh").IsRequired(false);
    }
}
