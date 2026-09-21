using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class RadioTherapyTypeDbEntityConfiguration : IEntityTypeConfiguration<RadioTherapyTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<RadioTherapyTypeDbEntity> builder)
    {
        builder.ToTable("N017").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.RadioTherapyTypeId).HasColumnName("ID_TLuch");
        builder.Property(prop => prop.RadioTherapyTypeName).HasColumnName("TLuch_Name").IsRequired(false);
    }
}