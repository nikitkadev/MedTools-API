using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DrugTherapyLineDbEntityConfiguration : IEntityTypeConfiguration<DrugTherapyLineDbEntity>
{
    public void Configure(EntityTypeBuilder<DrugTherapyLineDbEntity> builder)
    {
        builder.ToTable("N015").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.DrugTherapyLineId).HasColumnName("ID_TLek_L");
        builder.Property(prop => prop.DrugTherapyLineName).HasColumnName("TLek_Name_L").IsRequired(false);
    }
}
