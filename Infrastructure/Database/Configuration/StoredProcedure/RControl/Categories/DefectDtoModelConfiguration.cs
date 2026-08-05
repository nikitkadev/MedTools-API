using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.DefectsSanks;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class DefectDtoModelConfiguration : IEntityTypeConfiguration<DefectDto>
{
    public void Configure(EntityTypeBuilder<DefectDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.Kod).HasColumnName("kod").IsRequired(false);
        builder.Property(prop => prop.Comment).HasColumnName("comment");
    }
}
