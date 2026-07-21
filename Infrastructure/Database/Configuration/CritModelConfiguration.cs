using Infrastructure.Database.Enitites.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class CritModelConfiguration : IEntityTypeConfiguration<CritEntity>
{
    public void Configure(EntityTypeBuilder<CritEntity> builder)
    {
        builder.ToTable("crit").HasKey(crit => crit.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.KsgKpgUid).HasColumnName("ksg_kpg_uid");
        builder.Property(prop => prop.Crit).HasColumnName("crit").HasMaxLength(100).IsRequired(false);

        builder.HasOne<KsgKpgEntity>()
            .WithMany(ksg => ksg.CritEntities)
            .HasForeignKey(crit => crit.KsgKpgUid);
    }
}