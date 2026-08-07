using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Workspace;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.MedicalCases;

public class ConsulationDtoConfiguration : IEntityTypeConfiguration<ConsultationDto>
{
    public void Configure(EntityTypeBuilder<ConsultationDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.ConsultationUid).HasColumnName("uid");
        builder.Property(prop => prop.ConsultationPurposeCode).HasColumnName("consultation_purpose_code");
        builder.Property(prop => prop.ConsultationPurpose).HasColumnName("consultation_purpose").IsRequired(false);
        builder.Property(prop => prop.ConsultationDate).HasColumnName("dt_cons").IsRequired(false);
    }
}
