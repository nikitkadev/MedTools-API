using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure.Elements;

public sealed class ConcomitantDiagnosisDbEntityConfiguration : IEntityTypeConfiguration<ConcomitantDiagnosisDbEntity>
{
    public void Configure(EntityTypeBuilder<ConcomitantDiagnosisDbEntity> builder)
    {
        builder.ToTable("ds2").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");

        builder.Property(prop => prop.DiagnosisName).HasColumnName("ds2");

        builder
            .HasOne(concomitantDiagnosis => concomitantDiagnosis.MedicalCase)
            .WithMany(medicalCase => medicalCase.ConcomitantDiagnoses)
            .HasForeignKey(concomitantDiagnosis => concomitantDiagnosis.MedicalCaseUid);
    }
}
