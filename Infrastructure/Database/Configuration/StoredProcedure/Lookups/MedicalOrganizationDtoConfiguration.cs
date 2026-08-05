using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Dtos.Lookups;

namespace Infrastructure.Database.Configuration.StoredProcedure.Lookups;

public class MedicalOrganizationDtoConfiguration : IEntityTypeConfiguration<MedicalOrganizationDto>
{
    public void Configure(EntityTypeBuilder<MedicalOrganizationDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalOrganizationCode).HasColumnName("mo_code");
        builder.Property(prop => prop.MedicalOrganizationName).HasColumnName("mo_name");
    }
}
