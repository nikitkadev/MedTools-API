using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.ProvidedServices;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.ProvidedServices;

public class MedicalDeviceDtoConfiguration : IEntityTypeConfiguration<MedicalDeviceDto>
{
    public void Configure(EntityTypeBuilder<MedicalDeviceDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalDeviceUid).HasColumnName("uid");
        builder.Property(prop => prop.ImplantationDate).HasColumnName("date_med");
        builder.Property(prop => prop.MedicalDeviceTypeCode).HasColumnName("code_meddev");
        builder.Property(prop => prop.SerialNumber).HasColumnName("number_ser");

    }
}
