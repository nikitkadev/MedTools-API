using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.ClinicalGroups;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.ClinicalGroups;

internal class TreatmentComplexityCoefficientDtoConfiguration : IEntityTypeConfiguration<TreatmentComplexityCoefficientDto>
{
    public void Configure(EntityTypeBuilder<TreatmentComplexityCoefficientDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.TreatmentComplexityCoefficientUid).HasColumnName("uid");
        builder.Property(prop => prop.ComplexityCoefficientNumber).HasColumnName("idsl").IsRequired(false);
        builder.Property(prop => prop.ComplexityCoefficientValue).HasColumnName("z_sl");
    }
}
