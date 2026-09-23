using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class DiagnosticMethodDbEntityConfiguration : IEntityTypeConfiguration<DiagnosticMethodDbEntity>
{
    public void Configure(EntityTypeBuilder<DiagnosticMethodDbEntity> builder)
    {
        builder.ToTable("V029").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.DiagnosticMethodId).HasColumnName("idmet");
        builder.Property(prop => prop.DiagnosticMethodName).HasColumnName("n_met").IsRequired(false);
    }
}