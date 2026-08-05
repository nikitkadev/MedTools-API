using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.Lookups;

namespace Infrastructure.Database.Configuration.StoredProcedure.Lookups;

public class BillingPeriodDtoConfiguration : IEntityTypeConfiguration<BillingPeriodDto>
{
    public void Configure(EntityTypeBuilder<BillingPeriodDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.BillingYear).HasColumnName("billing_year");
        builder.Property(prop => prop.BillingMonth).HasColumnName("billing_month");
    }
}
