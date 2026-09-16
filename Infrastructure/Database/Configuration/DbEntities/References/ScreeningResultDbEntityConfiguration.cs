using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class ScreeningResultDbEntityConfiguration : IEntityTypeConfiguration<ScreeningResultDbEntity>
{
    public void Configure(EntityTypeBuilder<ScreeningResultDbEntity> builder)
    {
        builder.ToTable("V017").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ScreeningResultId).HasColumnName("iddr");
        builder.Property(prop => prop.ScreeningResultName).HasColumnName("drname");
    }
}
