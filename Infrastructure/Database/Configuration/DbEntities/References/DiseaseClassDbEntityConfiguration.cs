using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DiseaseClassDbEntityConfiguration : IEntityTypeConfiguration<DiseaseClassDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseClassDbEntity> builder)
    {
        builder.ToTable("DIM_MKB_Class").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("UID");
        builder.Property(prop => prop.ClassName).HasColumnName("Name").IsRequired(false);
        builder.Property(prop => prop.StartingDiseasePrefix).HasColumnName("DSB").IsRequired(false);
        builder.Property(prop => prop.EndingDiseasePrefix).HasColumnName("DSE").IsRequired(false);
    }
}
