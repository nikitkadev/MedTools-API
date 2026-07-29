using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Medical;

namespace Infrastructure.Database.Configuration.Entities;

public class SankModelConfiguration : IEntityTypeConfiguration<SankEntity>
{
    public void Configure(EntityTypeBuilder<SankEntity> builder)
    {
        builder.ToTable("sank").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.SluchUid).HasColumnName("sluch_uid");
        builder.Property(prop => prop.SankInfoUid).HasColumnName("sank_uid");

        builder.Property(prop => prop.SCode).HasColumnName("s_code").HasMaxLength(36);
        builder.Property(prop => prop.SSum).HasColumnName("s_sum");
        builder.Property(prop => prop.STip).HasColumnName("s_tip").HasMaxLength(3);
        builder.Property(prop => prop.SOsn).HasColumnName("s_osn");
        builder.Property(prop => prop.SCom).HasColumnName("s_com").HasMaxLength(250).IsRequired(false);
        builder.Property(prop => prop.SIst).HasColumnName("s_ist");
        builder.Property(prop => prop.SEDCol).HasColumnName("s_ed_col");
        builder.Property(prop => prop.SKsg).HasColumnName("s_ksg").HasMaxLength(20).IsRequired(false);
        builder.Property(prop => prop.SNact).HasColumnName("s_nact").HasMaxLength(30);
        builder.Property(prop => prop.SDact).HasColumnName("s_dact");
        builder.Property(prop => prop.SCodex).HasColumnName("s_codex").HasMaxLength(10).IsRequired(false);


        builder.HasOne<SlEntity>()
            .WithMany(sl => sl.Sanks)
            .HasForeignKey(sank => sank.SluchUid);

        builder.HasOne(x => x.SankInfo)
            .WithMany(x => x.Sanks)
            .HasForeignKey(x => x.SankInfoUid);
    }
}