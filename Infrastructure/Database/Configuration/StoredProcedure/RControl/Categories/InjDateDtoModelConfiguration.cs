using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class InjDateDtoModelConfiguration : IEntityTypeConfiguration<InjDateDto>
{
    public void Configure(EntityTypeBuilder<InjDateDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.DateInj).HasColumnName("date_inj");
    }
}
