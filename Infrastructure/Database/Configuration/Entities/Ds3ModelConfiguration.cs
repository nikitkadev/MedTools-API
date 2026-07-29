using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Medical;

namespace Infrastructure.Database.Configuration.Entities;

public class Ds3ModelConfiguration : IEntityTypeConfiguration<Ds3Entity>
{
    public void Configure(EntityTypeBuilder<Ds3Entity> builder)
    {
        builder.ToTable("ds3").HasKey(ds3 => ds3.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.SluchUid).HasColumnName("sluch_uid");
        builder.Property(prop => prop.Ds3).HasColumnName("ds3").HasMaxLength(10);

        builder .HasOne<SlEntity>()
            .WithMany(sl => sl.Ds3s)
            .HasForeignKey(ds3 => ds3.SluchUid);
    }
}