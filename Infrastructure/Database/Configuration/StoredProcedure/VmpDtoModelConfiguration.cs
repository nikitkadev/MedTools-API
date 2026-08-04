using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.KsgVmp;

namespace Infrastructure.Database.Configuration.StoredProcedure;

public class VmpDtoModelConfiguration : IEntityTypeConfiguration<VmpDto>
{
    public void Configure(EntityTypeBuilder<VmpDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.VidHmp).HasColumnName("vid_hmp").IsRequired(false);
        builder.Property(prop => prop.MetodHmp).HasColumnName("metod_hmp").IsRequired(false);
        builder.Property(prop => prop.TalD).HasColumnName("tal_d").IsRequired(false);
        builder.Property(prop => prop.TalNum).HasColumnName("tal_num").IsRequired(false);
        builder.Property(prop => prop.TalP).HasColumnName("tal_p").IsRequired(false);
    }
}
