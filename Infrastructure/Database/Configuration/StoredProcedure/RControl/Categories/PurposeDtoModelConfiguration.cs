using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.NazNapr;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class PurposeDtoModelConfiguration : IEntityTypeConfiguration<PurposeDto>
{
    public void Configure(EntityTypeBuilder<PurposeDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.NazN).HasColumnName("naz_n");
        builder.Property(prop => prop.NazR).HasColumnName("naz_r");
        builder.Property(prop => prop.NazV).HasColumnName("naz_v").IsRequired(false);
        builder.Property(prop => prop.NazUsl).HasColumnName("naz_usl").IsRequired(false); ;
        builder.Property(prop => prop.NaprDate).HasColumnName("napr_date").IsRequired(false); ;
        builder.Property(prop => prop.NaprMo).HasColumnName("napr_mo").IsRequired(false); ;
        builder.Property(prop => prop.NazPmp).HasColumnName("naz_pmp").IsRequired(false); ;
        builder.Property(prop => prop.NazPk).HasColumnName("naz_pk").IsRequired(false); ;
    }
}
