using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Oncology;

public class ContraindicationDtoConfiguration : IEntityTypeConfiguration<ContraindicationDto>
{
    public void Configure(EntityTypeBuilder<ContraindicationDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ContraindicationUid).HasColumnName("uid");
        builder.Property(prop => prop.ContraindicationCode).HasColumnName("contraindication_code");
        builder.Property(prop => prop.Contraindication).HasColumnName("contraindication");
        builder.Property(prop => prop.ContraindicationDate).HasColumnName("d_prot");
    }
}
