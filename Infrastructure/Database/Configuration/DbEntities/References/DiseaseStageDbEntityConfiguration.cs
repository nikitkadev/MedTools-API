using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References
{
    public sealed class DiseaseStageDbEntityConfiguration : IEntityTypeConfiguration<DiseaseStageDbEntity>
    {
        public void Configure(EntityTypeBuilder<DiseaseStageDbEntity> builder)
        {
            builder.ToTable("N002").HasKey(entity => entity.Uid);

            builder.Property(prop => prop.Uid).HasColumnName("uid");

            builder.Property(prop => prop.StageId).HasColumnName("Id_St");
            builder.Property(prop => prop.StageName).HasColumnName("Kod_St").IsRequired(false);
        }
    }
}
