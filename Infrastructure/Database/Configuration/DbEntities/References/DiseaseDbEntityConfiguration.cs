using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DiseaseDbEntityConfiguration : IEntityTypeConfiguration<DiseaseDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseDbEntity> builder)
    {
        builder.ToTable("DIM_MKB").HasNoKey();

        builder.Property(prop => prop.DiseaseCode).HasColumnName("DS").IsRequired(false);
        builder.Property(prop => prop.DiseaseName).HasColumnName("NAME_DS").IsRequired(false);
        builder.Property(prop => prop.ClassCode).HasColumnName("Class").IsRequired(false);
        builder.Property(prop => prop.SubClassCode).HasColumnName("SubClass").IsRequired(false);
    }
}
