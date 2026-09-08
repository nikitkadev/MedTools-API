using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities.InvoiceStructure.Headings;

namespace Infrastructure.Database.Configuration.DbEntities.InvoiceStructure.Headings;

public sealed class PersonRegistryHeadingDbEntityConfiguration : IEntityTypeConfiguration<PersonRegistryHeadingDbEntity>
{
    public void Configure(EntityTypeBuilder<PersonRegistryHeadingDbEntity> builder)
    {
        builder.ToTable("p_zglv").HasKey(entity => entity.PersonRegistryUid);

        builder.Property(prop => prop.PersonRegistryUid).HasColumnName("pers_list_uid");

        builder.Property(prop => prop.Version).HasColumnName("version").IsRequired(false);
        builder.Property(prop => prop.Date).HasColumnName("data").IsRequired(false);
        builder.Property(prop => prop.PersonRegistryFilename).HasColumnName("filename").IsRequired(false);
        builder.Property(prop => prop.MedicalRegistryFilename).HasColumnName("filename1").IsRequired(false);

    }
}
