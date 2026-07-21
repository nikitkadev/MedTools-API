using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Medical;

namespace Infrastructure.Database.Configuration;

public class UslDopParamModelConfiguration : IEntityTypeConfiguration<UslDopParamEntity>
{
    public void Configure(EntityTypeBuilder<UslDopParamEntity> builder)
    {
        builder.ToTable("uslDopParam").HasKey(dop => dop.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.UslUid).HasColumnName("usl_uid");
        builder.Property(prop => prop.Kod).HasColumnName("kod").HasMaxLength(10);
    }
}