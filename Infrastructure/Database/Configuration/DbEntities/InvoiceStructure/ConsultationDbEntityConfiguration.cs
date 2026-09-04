using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.InvoiceStructure;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure;

public sealed class ConsultationDbEntityConfiguration : IEntityTypeConfiguration<ConsultationDbEntity>
{
    public void Configure(EntityTypeBuilder<ConsultationDbEntity> builder)
    {
        builder.ToTable("cons").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.ConsultationPurposeCode).HasColumnName("pr_cons");
        builder.Property(prop => prop.ConsultationDate).HasColumnName("dt_cons").IsRequired(false);
    }
}