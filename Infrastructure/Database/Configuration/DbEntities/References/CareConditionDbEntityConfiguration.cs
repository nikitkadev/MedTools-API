using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class CareConditionDbEntityConfiguration : IEntityTypeConfiguration<CareConditionDbEntity>
{
    public void Configure(EntityTypeBuilder<CareConditionDbEntity> builder)
    {
        builder.ToTable("v006").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ConditionId).HasColumnName("idump");
        builder.Property(prop => prop.ConditionName).HasColumnName("umpname");
    }
}