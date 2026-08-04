using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.Categories.DefectsSanks;

namespace Infrastructure.Database.Configuration.StoredProcedureModel;

public class SankDtoModelConfiguration : IEntityTypeConfiguration<SankDto>
{
    public void Configure(EntityTypeBuilder<SankDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.Uid).HasColumnName("uid");
        builder.Property(prop => prop.SCode).HasColumnName("s_code");
        builder.Property(prop => prop.SSum).HasColumnName("s_sum");
        builder.Property(prop => prop.STip).HasColumnName("s_tip");
        builder.Property(prop => prop.SOsn).HasColumnName("s_osn");
        builder.Property(prop => prop.SEDCol).HasColumnName("s_ed_col");
        builder.Property(prop => prop.SDact).HasColumnName("s_dact");
        builder.Property(prop => prop.SNact).HasColumnName("s_nact");
        builder.Property(prop => prop.SCodex).HasColumnName("s_codex").IsRequired(false);
        builder.Property(prop => prop.SCom).HasColumnName("s_com").IsRequired(false);
        builder.Property(prop => prop.Filename).HasColumnName("filename").IsRequired(false);
        builder.Property(prop => prop.Year).HasColumnName("year").IsRequired(false);
        builder.Property(prop => prop.Month).HasColumnName("month").IsRequired(false);
        builder.Property(prop => prop.UploadeDate).HasColumnName("uploaddate").IsRequired(false);
    }
}
