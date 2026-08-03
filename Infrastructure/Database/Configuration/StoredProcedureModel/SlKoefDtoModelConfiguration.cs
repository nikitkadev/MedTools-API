using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.KsgVmp;

namespace Infrastructure.Database.Configuration.StoredProcedureModel;

public class SlKoefDtoModelConfiguration : IEntityTypeConfiguration<SlKoefDto>
{
    public void Configure(EntityTypeBuilder<SlKoefDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(ptop => ptop.IdSl).HasColumnName("idsl");
        builder.Property(ptop => ptop.ZSl).HasColumnName("z_sl");
    }
}
