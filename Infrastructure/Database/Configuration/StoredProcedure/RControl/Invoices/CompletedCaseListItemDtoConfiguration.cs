using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Invoices;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Invoices;

public class CompletedCaseListItemDtoConfiguration : IEntityTypeConfiguration<CompletedCaseListItemDto>
{
    public void Configure(EntityTypeBuilder<CompletedCaseListItemDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.CompletedCaseUid).HasColumnName("zsluid");
        builder.Property(prop => prop.EntryNumber).HasColumnName("idcase");
        builder.Property(prop => prop.AmountBilled).HasColumnName("sumv");
        builder.Property(prop => prop.ApprovedAmount).HasColumnName("sump").IsRequired(false);
        builder.Property(prop => prop.InsuranceCompanyApprovedAmount).HasColumnName("smo_sump").IsRequired(false);
        builder.Property(prop => prop.MedicalCareConditions).HasColumnName("usl_ok");
        builder.Property(prop => prop.EntryPositionNumber).HasColumnName("n_zap");
        builder.Property(prop => prop.PatientLastName).HasColumnName("fam");
        builder.Property(prop => prop.PatientFirstName).HasColumnName("im");
        builder.Property(prop => prop.PatientMiddleName).HasColumnName("ot");
        builder.Property(prop => prop.InsurancePolicySeries).HasColumnName("spolis").IsRequired(false);
        builder.Property(prop => prop.InsurancePolicyNumber).HasColumnName("npolis");
    }
}
