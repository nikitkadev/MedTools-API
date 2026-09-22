using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class TherapyRegimenDbEntityConfiguration : IEntityTypeConfiguration<TherapyRegimenDbEntity>
{
    public void Configure(EntityTypeBuilder<TherapyRegimenDbEntity> builder)
    {
        builder.ToTable("V024").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.TherapyRegimenId).HasColumnName("iddkk");
        builder.Property(prop => prop.TherapyRegimenName).HasColumnName("dkkname").IsRequired(false);
    }
}
