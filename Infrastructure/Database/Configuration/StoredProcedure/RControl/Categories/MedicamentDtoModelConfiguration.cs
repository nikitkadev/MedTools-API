using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;


public class MedicamentDtoModelConfiguration : IEntityTypeConfiguration<MedicamentDto>
{
    public void Configure(EntityTypeBuilder<MedicamentDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.Regnum).HasColumnName("regnum");
        builder.Property(prop => prop.RegnumDop).HasColumnName("regnum_dop").IsRequired(false);
        builder.Property(prop => prop.CodeSh).HasColumnName("code_sh").IsRequired(false);
    }
}
