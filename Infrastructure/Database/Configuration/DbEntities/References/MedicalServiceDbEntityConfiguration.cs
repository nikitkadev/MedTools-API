using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class MedicalServiceDbEntityConfiguration : IEntityTypeConfiguration<MedicalServiceDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalServiceDbEntity> builder)
    {
        builder.ToTable("V001").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ServiceId).HasColumnName("ID");
        builder.Property(prop => prop.ServiceCode).HasColumnName("S_CODE");
        builder.Property(prop => prop.ServiceName).HasColumnName("NAME").IsRequired(false);
    }
}