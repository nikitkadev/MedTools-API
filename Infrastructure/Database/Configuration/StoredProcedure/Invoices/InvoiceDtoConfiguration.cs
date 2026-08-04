using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Invoices;

namespace Infrastructure.Database.Configuration.StoredProcedure.Invoices;

public class InvoiceDtoConfiguration : IEntityTypeConfiguration<InvoiceDto>
{
    public void Configure(EntityTypeBuilder<InvoiceDto> builder)
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
