using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Categories.MedicalCase;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.MedicalCases;

public class DefectDtoConfiguration : IEntityTypeConfiguration<DefectDto>
{
    public void Configure(EntityTypeBuilder<DefectDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.DefectUid).HasColumnName("uid");
        builder.Property(prop => prop.Code).HasColumnName("kod");
        builder.Property(prop => prop.Comment).HasColumnName("comment");
    }
}