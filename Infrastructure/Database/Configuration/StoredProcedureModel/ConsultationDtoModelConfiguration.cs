using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedureModel;

public class ConsultationDtoModelConfiguration : IEntityTypeConfiguration<ConsultationDto>
{
    public void Configure(EntityTypeBuilder<ConsultationDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.DtCons).HasColumnName("dt_cons").IsRequired(false);
        builder.Property(prop => prop.PrCons).HasColumnName("pr_cons");
    }
}
