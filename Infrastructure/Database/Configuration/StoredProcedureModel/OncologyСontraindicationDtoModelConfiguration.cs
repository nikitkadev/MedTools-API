using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedureModel;

public class OncologyСontraindicationDtoModelConfiguration : IEntityTypeConfiguration<OncologyContraindicationDto>
{
    public void Configure(EntityTypeBuilder<OncologyContraindicationDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Prot).HasColumnName("prot");
        builder.Property(prop => prop.DProt).HasColumnName("d_prot");
    }
}
