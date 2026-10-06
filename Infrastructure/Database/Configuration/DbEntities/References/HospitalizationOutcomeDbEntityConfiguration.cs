using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class HospitalizationOutcomeDbEntityConfiguration : IEntityTypeConfiguration<HospitalizationOutcomeDbEntity>
{
    public void Configure(EntityTypeBuilder<HospitalizationOutcomeDbEntity> builder)
    {
        builder.ToTable("V009").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.HospitalizationOutcomeId).HasColumnName("idrmp");
        builder.Property(prop => prop.CareConditionId).HasColumnName("id_uslov");
        builder.Property(prop => prop.HospitalizationOutcomeName).HasColumnName("rmpname");
    }
}
