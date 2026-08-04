using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.NazNapr;

namespace Infrastructure.Database.Configuration.StoredProcedure;

public class DirectionDtoModelConfiguration : IEntityTypeConfiguration<DirectionDto>
{
    public void Configure(EntityTypeBuilder<DirectionDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.NaprDate).HasColumnName("napr_date");
        builder.Property(prop => prop.NaprMo).HasColumnName("napr_mo").IsRequired(false);
        builder.Property(prop => prop.NaprV).HasColumnName("napr_v");
        builder.Property(prop => prop.MetIssl).HasColumnName("met_issl").IsRequired(false);
        builder.Property(prop => prop.NaprUsl).HasColumnName("napr_usl").IsRequired(false);
    }
}
