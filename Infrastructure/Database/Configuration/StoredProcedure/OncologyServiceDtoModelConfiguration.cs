using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure;

public class OncologyServiceDtoModelConfiguration : IEntityTypeConfiguration<OncologyServiceDto>
{
    public void Configure(EntityTypeBuilder<OncologyServiceDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.UslTip).HasColumnName("usl_tip");
        builder.Property(prop => prop.HirTip).HasColumnName("hir_tip").IsRequired(false);
        builder.Property(prop => prop.LekTipL).HasColumnName("lek_tip_l").IsRequired(false);
        builder.Property(prop => prop.LekTipV).HasColumnName("lek_tip_v").IsRequired(false);
        builder.Property(prop => prop.LuchTip).HasColumnName("luch_tip").IsRequired(false);
        builder.Property(prop => prop.PPTR).HasColumnName("pptr").IsRequired(false);
    }
}