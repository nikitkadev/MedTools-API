using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure.Elements;

public sealed class ClassificationCriterionDbEntityConfiguration : IEntityTypeConfiguration<ClassificationCriterionDbEntity>
{
    public void Configure(EntityTypeBuilder<ClassificationCriterionDbEntity> builder)
    {
        builder.ToTable("crit").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.ClinicalGroupUid).HasColumnName("ksg_kpg_uid");

        builder.Property(prop => prop.ClassificationCriterionName).HasColumnName("crit").IsRequired(false);
    }
}
