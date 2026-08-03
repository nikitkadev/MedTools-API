using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Medical;

namespace Infrastructure.Database.Configuration.Entities;

public class DateInjModelConfiguration : IEntityTypeConfiguration<DateInjEntity>
{
    public void Configure(EntityTypeBuilder<DateInjEntity> builder)
    {
        builder.ToTable("date_inj").HasKey(di => di.Uid);

        builder.Property(prop => prop.Uid).ValueGeneratedOnAdd();
        builder.Property(prop => prop.LekPrUid).HasColumnName("lek_pr_uid");
        builder.Property(prop => prop.DateInj).HasColumnName("date_inj");

        builder.HasOne<LekPrEntity>()
            .WithMany(lek => lek.DateInjEntities)
            .HasForeignKey(inj => inj.LekPrUid);
    }
}