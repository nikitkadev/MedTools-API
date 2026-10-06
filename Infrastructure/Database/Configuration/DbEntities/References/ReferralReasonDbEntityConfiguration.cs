using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Database.Configuration.DbEntities.References;

public sealed class ReferralReasonDbEntityConfiguration : IEntityTypeConfiguration<ReferralReasonDbEntity>
{
    public void Configure(EntityTypeBuilder<ReferralReasonDbEntity> builder)
    {
        builder.ToTable("N018").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ReferralReasonId).HasColumnName("id_reas");
        builder.Property(prop => prop.ReferralReasonName).HasColumnName("reas_name");

    }
}
