using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.Oncology;

namespace Infrastructure.Database.Configuration.StoredProcedureModel;

public class InjectionDtoModelConfiguration : IEntityTypeConfiguration<InjectionDto>
{
    public void Configure(EntityTypeBuilder<InjectionDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.DateInj).HasColumnName("date_inj");
        builder.Property(prop => prop.KvInj).HasColumnName("kv_inj").IsRequired(false);
        builder.Property(prop => prop.KizInj).HasColumnName("kiz_inj").IsRequired(false);
        builder.Property(prop => prop.SInj).HasColumnName("s_inj").IsRequired(false);
        builder.Property(prop => prop.SvInj).HasColumnName("sv_inj").IsRequired(false);
        builder.Property(prop => prop.SizInj).HasColumnName("siz_inj").IsRequired(false);
        builder.Property(prop => prop.RedInj).HasColumnName("red_inj").IsRequired(false);
    }
}
