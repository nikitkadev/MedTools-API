using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.KsgVmp;

namespace Infrastructure.Database.Configuration.StoredProcedure;

public class CritDtoModelConfiguration : IEntityTypeConfiguration<CritDto>
{
    public void Configure(EntityTypeBuilder<CritDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.Crit).HasColumnName("crit");
    }
}
