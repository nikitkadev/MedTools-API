using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Medical;

namespace Infrastructure.Database.Configuration.Entities;

public sealed class SankInfoModelConfiguration : IEntityTypeConfiguration<SankInfoEntity>
{
    public void Configure(EntityTypeBuilder<SankInfoEntity> builder)
    {
        builder.ToTable("Sank_Info").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.ZlListUid).HasColumnName("zl_list_uid");
        builder.Property(prop => prop.Filename).HasColumnName("filename").HasMaxLength(128).IsRequired(false);
        builder.Property(prop => prop.UploadeDate).HasColumnName("uploaddate").IsRequired(false);
        builder.Property(prop => prop.Code).HasColumnName("code").IsRequired(false);
        builder.Property(prop => prop.CodeMo).HasColumnName("code_mo").HasMaxLength(6).IsRequired(false);
        builder.Property(prop => prop.Year).HasColumnName("year");
        builder.Property(prop => prop.Month).HasColumnName("month").IsRequired(false);
        builder.Property(prop => prop.NSchet).HasColumnName("nschet").HasMaxLength(15).IsRequired(false);
        builder.Property(prop => prop.DSchet).HasColumnName("dschet").IsRequired(false);
        builder.Property(prop => prop.Plat).HasColumnName("plat").HasMaxLength(5).IsRequired(false);
        builder.Property(prop => prop.Summav).HasColumnName("summav").IsRequired(false);
        builder.Property(prop => prop.SmoSummap).HasColumnName("smo_summap").IsRequired(false);
        builder.Property(prop => prop.SmoSankMek).HasColumnName("smo_sank_mek").IsRequired(false);
        builder.Property(prop => prop.SmoSankMee).HasColumnName("smo_sank_mee").IsRequired(false);
        builder.Property(prop => prop.SmoSankEkmp).HasColumnName("smo_sank_ekmp").IsRequired(false);
        builder.Property(prop => prop.SankYear).HasColumnName("sank_year").IsRequired(false);
        builder.Property(prop => prop.SankMonth).HasColumnName("sank_month").IsRequired(false);

        builder.HasMany(x => x.Sanks)
            .WithOne(x => x.SankInfo)
            .HasForeignKey(x => x.SankInfoUid);
    }
}
