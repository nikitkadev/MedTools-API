using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure.Elements;

public sealed class ContraindicationDbEntityConfiguration : IEntityTypeConfiguration<ContraindicationDbEntity>
{
    public void Configure(EntityTypeBuilder<ContraindicationDbEntity> builder)
    {
        builder.ToTable("b_prot").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.OncologyCaseUid).HasColumnName("onk_sl_uid");

        builder.Property(prop => prop.ContraindicationCode).HasColumnName("prot");
        builder.Property(prop => prop.ContraindicationDate).HasColumnName("d_prot");
    }
}
