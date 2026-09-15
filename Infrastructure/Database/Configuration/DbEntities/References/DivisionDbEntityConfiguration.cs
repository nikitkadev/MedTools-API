using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DivisionDbEntityConfiguration : IEntityTypeConfiguration<DivisionDbEntity>
{
    public void Configure(EntityTypeBuilder<DivisionDbEntity> builder)
    {
        builder.ToTable("F033").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.DivisionId).HasColumnName("UIDSPMO").IsRequired(false);
        builder.Property(prop => prop.DivisionName).HasColumnName("NAM_SK_SPMO").IsRequired(false);
    }
}