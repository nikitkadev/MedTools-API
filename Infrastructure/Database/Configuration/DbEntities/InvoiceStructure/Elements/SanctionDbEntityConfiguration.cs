using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure.Elements;

public sealed class SanctionDbEntityConfiguration : IEntityTypeConfiguration<SanctionDbEntity>
{
    public void Configure(EntityTypeBuilder<SanctionDbEntity> builder)
    {
        builder.ToTable("sank").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.MedicalCaseUid).HasColumnName("sluch_uid");
        builder.Property(prop => prop.SanctionDetailsUid).HasColumnName("sank_uid");

        builder.Property(prop => prop.SanctionCode).HasColumnName("s_code");
        builder.Property(prop => prop.SanctionAmount).HasColumnName("s_sum");
        builder.Property(prop => prop.ControlTypeCode).HasColumnName("s_tip");
        builder.Property(prop => prop.RefusalReasonCode).HasColumnName("s_osn");
        builder.Property(prop => prop.Comment).HasColumnName("s_com");
        builder.Property(prop => prop.Source).HasColumnName("s_ist");
        builder.Property(prop => prop.UnitsRemoved).HasColumnName("s_ed_col");
        builder.Property(prop => prop.ClinicalStatisticalGroupNumber).HasColumnName("s_ksg");
        builder.Property(prop => prop.ExpertiseActNumber).HasColumnName("s_nact");
        builder.Property(prop => prop.ExpertiseActDate).HasColumnName("s_dact");
        builder.Property(prop => prop.ExpertCode).HasColumnName("s_codex");
    }
}