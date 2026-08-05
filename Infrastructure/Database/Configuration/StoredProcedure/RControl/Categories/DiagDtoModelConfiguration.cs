using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class DiagDtoModelConfiguration : IEntityTypeConfiguration<DiagDto>
{
    public void Configure(EntityTypeBuilder<DiagDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.DiagDate).HasColumnName("diag_date").IsRequired(false);
        builder.Property(prop => prop.DiagTip).HasColumnName("diag_tip").IsRequired(false);
        builder.Property(prop => prop.DiagCode).HasColumnName("diag_code").IsRequired(false);
        builder.Property(prop => prop.DiagRslt).HasColumnName("diag_rslt").IsRequired(false);
        builder.Property(prop => prop.RecRslt).HasColumnName("rec_rslt").IsRequired(false);
    }
}
