using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Medical;

namespace Infrastructure.Database.Configuration;

public class ConsModelConfiguration : IEntityTypeConfiguration<ConsEntity>
{
    public void Configure(EntityTypeBuilder<ConsEntity> builder)
    {
        builder.ToTable("cons").HasKey(cons => cons.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.SluchUid).HasColumnName("sluch_uid");
        builder.Property(prop => prop.PrCons).HasColumnName("pr_cons");
        builder.Property(prop => prop.DtCons).HasColumnName("dt_cons").IsRequired(false);

        builder.HasOne<SlEntity>()
            .WithMany(sl => sl.Cons)
            .HasForeignKey(cons => cons.SluchUid);
    }
}