using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class MedicalCareTypeDbEntityConfiguration : IEntityTypeConfiguration<MedicalCareTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCareTypeDbEntity> builder)
    {
        builder.ToTable("v008").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("idvmp");

        builder.Property(prop => prop.MedicalCareName).HasColumnName("vmpname");
    }
}
