using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class CareFormDbEntityConfiguration : IEntityTypeConfiguration<CareFormDbEntity>
{
    public void Configure(EntityTypeBuilder<CareFormDbEntity> builder)
    {
        builder.ToTable("V014").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.CareFormId).HasColumnName("IDFRMMP");
        builder.Property(prop => prop.CareFormName).HasColumnName("FRMMPNAME").IsRequired(false);
    }
}
