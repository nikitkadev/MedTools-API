using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.KsgVmp;

namespace Infrastructure.Database.Configuration.StoredProcedure;

public class KsgKpgDtoModelConfiguration : IEntityTypeConfiguration<KsgKpgDto>
{
    public void Configure(EntityTypeBuilder<KsgKpgDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.Ksg).HasColumnName("ksg").IsRequired(false);
        builder.Property(prop => prop.NKsg).HasColumnName("n_ksg");
        builder.Property(prop => prop.VerKsg).HasColumnName("ver_ksg");
        builder.Property(prop => prop.KsgPg).HasColumnName("ksg_pg");
        builder.Property(prop => prop.NKpg).HasColumnName("n_kpg").IsRequired(false);
        builder.Property(prop => prop.KoefZ).HasColumnName("koef_z");
        builder.Property(prop => prop.KoefUp).HasColumnName("koef_up");
        builder.Property(prop => prop.Bztsz).HasColumnName("bztsz");
        builder.Property(prop => prop.KoefD).HasColumnName("koef_d");
        builder.Property(prop => prop.KoefU).HasColumnName("koef_u");
        builder.Property(prop => prop.SlK).HasColumnName("sl_k");
        builder.Property(prop => prop.ItSl).HasColumnName("it_sl").IsRequired(false);
    }
}