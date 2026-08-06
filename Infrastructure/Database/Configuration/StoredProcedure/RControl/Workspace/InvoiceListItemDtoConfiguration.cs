using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Workspace;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Workspace;

public class InvoiceListItemDtoConfiguration : IEntityTypeConfiguration<InvoiceListItemDto>
{
    public void Configure(EntityTypeBuilder<InvoiceListItemDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InvoiceUid).HasColumnName("schet_uid");
        builder.Property(prop => prop.Number).HasColumnName("nschet");
        builder.Property(prop => prop.BillingDate).HasColumnName("dschet");
        builder.Property(prop => prop.Amount).HasColumnName("summav");
        builder.Property(prop => prop.MedicalCasesCount).HasColumnName("sd_z");
        builder.Property(prop => prop.Status).HasColumnName("stat");
    }
}
