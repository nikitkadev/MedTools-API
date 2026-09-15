using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class VisitPlaceDbEntityConfiguration : IEntityTypeConfiguration<VisitPlaceDbEntity>
{
    public void Configure(EntityTypeBuilder<VisitPlaceDbEntity> builder)
    {
        builder.ToTable("V040").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.VisitPlaceId).HasColumnName("ID_MOP");
        builder.Property(prop => prop.VisitPlaceName).HasColumnName("N_MOP");
    }
}