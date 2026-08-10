using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Oncology;

public class InjectionDateDtoConfiguration : IEntityTypeConfiguration<InjectionDateDto>
{
    public void Configure(EntityTypeBuilder<InjectionDateDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.InjectionDateUid).HasColumnName("uid");
        builder.Property(prop => prop.AdministrationDate).HasColumnName("date_inj");
    }
}
