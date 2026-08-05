using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class OncSluchDtoModelConfiguration : IEntityTypeConfiguration<OncSluchDto>
{
    public void Configure(EntityTypeBuilder<OncSluchDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.SluchUid).HasColumnName("sluch_uid");
        builder.Property(prop => prop.Ds1T).HasColumnName("ds1_t").IsRequired(false);
        builder.Property(prop => prop.Stad).HasColumnName("stad").IsRequired(false);
        builder.Property(prop => prop.OnkT).HasColumnName("onk_t").IsRequired(false);
        builder.Property(prop => prop.OnkN).HasColumnName("onk_n").IsRequired(false);
        builder.Property(prop => prop.OnkM).HasColumnName("onk_m").IsRequired(false);
        builder.Property(prop => prop.Mtstz).HasColumnName("mtstz").IsRequired(false);
        builder.Property(prop => prop.Sod).HasColumnName("sod").IsRequired(false);
        builder.Property(prop => prop.KFr).HasColumnName("k_fr").IsRequired(false);
        builder.Property(prop => prop.Wei).HasColumnName("wei").IsRequired(false);
        builder.Property(prop => prop.Hei).HasColumnName("hei").IsRequired(false);
        builder.Property(prop => prop.Bsa).HasColumnName("bsa").IsRequired(false);
    }
}
