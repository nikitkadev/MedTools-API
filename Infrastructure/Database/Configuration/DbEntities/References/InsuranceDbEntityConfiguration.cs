using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class InsuranceDbEntityConfiguration : IEntityTypeConfiguration<InsuranceDbEntity>
{
    public void Configure(EntityTypeBuilder<InsuranceDbEntity> builder)
    {
        builder.ToTable("F002").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.InsuranceCode).HasColumnName("SMOCOD");
        builder.Property(prop => prop.InsuranceShortname).HasColumnName("NAM_SMOK");
    }
}