using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class PhysicianSpecialtyDbEntityConfiguration : IEntityTypeConfiguration<PhysicianSpecialtyDbEntity>
{
    public void Configure(EntityTypeBuilder<PhysicianSpecialtyDbEntity> builder)
    {
        builder.ToTable("V021").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.SpecialityId).HasColumnName("idspec");
        builder.Property(prop => prop.SpecialityName).HasColumnName("specname");
        builder.Property(prop => prop.SpecialityPostname).HasColumnName("postname");
    }
}
