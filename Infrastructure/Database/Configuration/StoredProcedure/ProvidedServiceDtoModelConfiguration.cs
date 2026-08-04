using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.ProvidedServices;

namespace Infrastructure.Database.Configuration.StoredProcedure;

public class ProvidedServiceDtoModelConfiguration : IEntityTypeConfiguration<ProvidedServiceDto>
{
    public void Configure(EntityTypeBuilder<ProvidedServiceDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.CodeUsl).HasColumnName("code_usl");
        builder.Property(prop => prop.VidVme).HasColumnName("vid_vme").IsRequired(false);
        builder.Property(prop => prop.Profil).HasColumnName("profil");
        builder.Property(prop => prop.Prvs).HasColumnName("prvs");
        builder.Property(prop => prop.Det).HasColumnName("det");
        builder.Property(prop => prop.DateIn).HasColumnName("date_in");
        builder.Property(prop => prop.DateOut).HasColumnName("date_out");
        builder.Property(prop => prop.Ds).HasColumnName("ds");
        builder.Property(prop => prop.KolUsl).HasColumnName("kol_usl");
        builder.Property(prop => prop.Tarif).HasColumnName("tarif").IsRequired(false);
        builder.Property(prop => prop.SumvUsl).HasColumnName("sumv_usl");
        builder.Property(prop => prop.Comentu).HasColumnName("comentu").IsRequired(false);
    }
}
