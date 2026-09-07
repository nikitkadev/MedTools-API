using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure.Elements;

public sealed class MedicationDbEntityConfiguration : IEntityTypeConfiguration<MedicationDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicationDbEntity> builder)
    {
        builder.ToTable("").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.OncologyServiceUid).HasColumnName("onk_usl_uid");

        builder.Property(prop => prop.DrugIdentifier).HasColumnName("regnum");
        builder.Property(prop => prop.DrugExtendedIdentifier).HasColumnName("regnum_dop").IsRequired(false);
        builder.Property(prop => prop.TherapyRegimenCode).HasColumnName("code_sh").IsRequired(false);

    }
}
