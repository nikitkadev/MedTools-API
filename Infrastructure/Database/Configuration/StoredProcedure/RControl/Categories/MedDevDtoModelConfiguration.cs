using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.RControl.Categories.ProvidedServices;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories;

public class MedDevDtoModelConfiguration : IEntityTypeConfiguration<MedDevDto>
{
    public void Configure(EntityTypeBuilder<MedDevDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.DateMed).HasColumnName("date_med");
        builder.Property(prop => prop.CodeMeddev).HasColumnName("code_meddev");
        builder.Property(prop => prop.NumberSer).HasColumnName("number_ser");
    }
}