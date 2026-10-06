using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DiseaseSubClassDbEntityConfiguration : IEntityTypeConfiguration<DiseaseSubClassDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseSubClassDbEntity> builder)
    {
        builder.ToTable("DIM_MKB_SubClass").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("UID");
        builder.Property(prop => prop.SubClassName).HasColumnName("Name").IsRequired(false);
        builder.Property(prop => prop.StartingDiseasePrefix).HasColumnName("DSB").IsRequired(false);
        builder.Property(prop => prop.EndingDiseasePrefix).HasColumnName("DSE").IsRequired(false);

    }
}
