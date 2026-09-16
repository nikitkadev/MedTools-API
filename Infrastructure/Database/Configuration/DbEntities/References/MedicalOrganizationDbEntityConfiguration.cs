using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class MedicalOrganizationDbEntityConfiguration : IEntityTypeConfiguration<MedicalOrganizationDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalOrganizationDbEntity> builder)
    {
        builder.ToTable("F003").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("MCOD");
        builder.Property(prop => prop.MedicalOrganizationShortname).HasColumnName("NAM_MOK");
    }
}