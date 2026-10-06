using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DrugTherapyCycleDbEntityConfiguration : IEntityTypeConfiguration<DrugTherapyCycleDbEntity>
{
    public void Configure(EntityTypeBuilder<DrugTherapyCycleDbEntity> builder)
    {
        builder.ToTable("N016").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.DrugTherapyCycleId).HasColumnName("ID_TLek_V");
        builder.Property(prop => prop.DrugTherapyCycleName).HasColumnName("TLek_Name_V").IsRequired(false);
    }
}