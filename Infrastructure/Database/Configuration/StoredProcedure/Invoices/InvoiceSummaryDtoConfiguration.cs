using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Invoices;

namespace Infrastructure.Database.Configuration.StoredProcedure.Invoices;

public class InvoiceSummaryDtoConfiguration : IEntityTypeConfiguration<InvoiceSummaryDto>
{
    public void Configure(EntityTypeBuilder<InvoiceSummaryDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InvoiceUid).HasColumnName("schet_uid");
        builder.Property(prop => prop.InvoiceUploadDate).HasColumnName("schet_uploaddate");
        builder.Property(prop => prop.Filename).HasColumnName("schet_filename");
        builder.Property(prop => prop.InvoiceAmount).HasColumnName("sumv");
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("tfoms_sump");
        builder.Property(prop => prop.MedicalEconomicControlPenalty).HasColumnName("tfoms_sank_mek");
        builder.Property(prop => prop.MedicalEconomicExpertisePenalty).HasColumnName("tfoms_sank_mee");
        builder.Property(prop => prop.MedicalCareQualityExpertisePenalty).HasColumnName("tfoms_sank_ekmp");
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_sump");
        builder.Property(prop => prop.InsuranceCompanyMedicalEconomicControlPenalty).HasColumnName("smo_sank_mek");
        builder.Property(prop => prop.InsuranceCompanyMedicalEconomicExpertisePenalty).HasColumnName("smo_sank_mee");
        builder.Property(prop => prop.InsuranceCompanyMedicalCareQualityExpertisePenalty).HasColumnName("smo_sank_ekmp");

    }
}
