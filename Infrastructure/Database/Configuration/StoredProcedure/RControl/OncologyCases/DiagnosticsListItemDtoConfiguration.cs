using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.OncologyCases;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.OncologyCases;

public class DiagnosticsListItemDtoConfiguration : IEntityTypeConfiguration<DiagnosticsListItemDto>
{
    public void Configure(EntityTypeBuilder<DiagnosticsListItemDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.DiagnosticsUid).HasColumnName("uid");
        builder.Property(prop => prop.SpecimenCollectionDate).HasColumnName("diag_date").IsRequired(false);
        builder.Property(prop => prop.DiagnosticType).HasColumnName("diag_tip").IsRequired(false);
        builder.Property(prop => prop.DiagnosticCode).HasColumnName("diag_code").IsRequired(false);
        builder.Property(prop => prop.DiagnosticResultCode).HasColumnName("diag_rslt").IsRequired(false);
        builder.Property(prop => prop.IsResultReceived).HasColumnName("rec_rslt").IsRequired(false);
    }
}
