using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.KsgVmp;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class CritDtoModelConfiguration : IEntityTypeConfiguration<CritDto>
{
    public void Configure(EntityTypeBuilder<CritDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.Crit).HasColumnName("crit");
    }
}
