using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class ControlTypeCodeDbEntityConfiguration : IEntityTypeConfiguration<ControlTypeCodeDbEntity>
{
    public void Configure(EntityTypeBuilder<ControlTypeCodeDbEntity> builder)
    {
        builder.ToTable("F006").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ControlTypeCodeId).HasColumnName("idvid");
        builder.Property(prop => prop.ControlTypeCodeName).HasColumnName("vidname").IsRequired(false);
    }
}