using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class OncologyServiceTypeDbEntityConfiguration : IEntityTypeConfiguration<OncologyServiceTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<OncologyServiceTypeDbEntity> builder)
    {
        builder.ToTable("N013").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ServiceId).HasColumnName("ID_TLech");
        builder.Property(prop => prop.ServiceName).HasColumnName("TLech_Name").IsRequired(false);
    }
}
