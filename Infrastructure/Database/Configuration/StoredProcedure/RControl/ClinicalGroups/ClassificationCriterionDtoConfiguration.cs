using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.ClinicalGroups;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.ClinicalGroups;

public class ClassificationCriterionDtoConfiguration : IEntityTypeConfiguration<ClassificationCriterionDto>
{
    public void Configure(EntityTypeBuilder<ClassificationCriterionDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ClassificationCriterionUid).HasColumnName("uid");
        builder.Property(prop => prop.ClassificationCriterion).HasColumnName("crit");
    }
}
