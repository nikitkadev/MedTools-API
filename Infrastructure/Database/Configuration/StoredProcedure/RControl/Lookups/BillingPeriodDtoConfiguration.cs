using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Lookups;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Lookups;

public class BillingPeriodDtoConfiguration : IEntityTypeConfiguration<BillingPeriodDto>
{
    public void Configure(EntityTypeBuilder<BillingPeriodDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.BillingYear).HasColumnName("billing_year");
        builder.Property(prop => prop.BillingMonth).HasColumnName("billing_month");
    }
}
