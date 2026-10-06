using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DiseaseCharacterDbEntityConfiguration : IEntityTypeConfiguration<DiseaseCharacterDbEntity>
{
    public void Configure(EntityTypeBuilder<DiseaseCharacterDbEntity> builder)
    {
        builder.ToTable("V027").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.CharacterId).HasColumnName("idcz");
        builder.Property(prop => prop.CharacterName).HasColumnName("n_cz").IsRequired(false);

    }
}
