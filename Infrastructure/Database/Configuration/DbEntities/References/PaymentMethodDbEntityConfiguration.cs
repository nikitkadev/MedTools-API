using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class PaymentMethodDbEntityConfiguration : IEntityTypeConfiguration<PaymentMethodDbEntity>
{
    public void Configure(EntityTypeBuilder<PaymentMethodDbEntity> builder)
    {
        builder.ToTable("V010").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("idsp");

        builder.Property(prop => prop.PaymentMethodName).HasColumnName("spname");
    }
}
