using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Medications;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Medications;

public class InjectionDtoConfiguration : IEntityTypeConfiguration<InjectionDto>
{
    public void Configure(EntityTypeBuilder<InjectionDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InjectionUid).HasColumnName("uid");
        builder.Property(prop => prop.AdministrationDate).HasColumnName("date_inj");
        builder.Property(prop => prop.AdministeredQuantity).HasColumnName("kv_inj").IsRequired(false);
        builder.Property(prop => prop.ConsumedQuantity).HasColumnName("kiz_inj").IsRequired(false);
        builder.Property(prop => prop.UnitCost).HasColumnName("s_inj").IsRequired(false);
        builder.Property(prop => prop.AdministeredCost).HasColumnName("sv_inj").IsRequired(false);
        builder.Property(prop => prop.ConsumedCost).HasColumnName("siz_inj").IsRequired(false);
        builder.Property(prop => prop.IsReductionApplied).HasColumnName("red_inj").IsRequired(false);
    }
}
