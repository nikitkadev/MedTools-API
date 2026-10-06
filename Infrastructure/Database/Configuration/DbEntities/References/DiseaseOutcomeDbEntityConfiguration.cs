using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DiseaseOutcomeDbEntityConfiguration : IEntityTypeConfiguration<DiseaseOutcomeDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseOutcomeDbEntity> builder)
    {
        builder.ToTable("v012").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.OutcomeId).HasColumnName("idiz");
        builder.Property(prop => prop.OutcomeName).HasColumnName("izname");
    }
}
