using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class ProvidedServiceDbEntityConfiguration : IEntityTypeConfiguration<ProvidedServiceDbEntity>
{
    public void Configure(EntityTypeBuilder<ProvidedServiceDbEntity> builder)
    {
        builder.ToTable("T003").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ProvidedServiceId).HasColumnName("KOD").IsRequired(false);
        builder.Property(prop => prop.ProvidedServiceName).HasColumnName("NAME").IsRequired(false);
    }
}
