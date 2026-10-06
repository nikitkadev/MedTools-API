using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.Database.DbEntities;

namespace Infrastructure.Database.Configuration.DbEntities;

public class UserDbEntityConfiguration : IEntityTypeConfiguration<UserDbEntity>
{
    public void Configure(EntityTypeBuilder<UserDbEntity> builder)
    {
        builder.ToTable("medtools_users").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(prop => prop.Username).HasColumnName("username").HasMaxLength(255);
        builder.Property(prop => prop.Email).HasColumnName("email").HasMaxLength(255);
        builder.Property(prop => prop.PasswordHash).HasColumnName("password_hash").HasMaxLength(255);
        builder.Property(prop => prop.FirstName).HasColumnName("name").HasMaxLength(255);
        builder.Property(prop => prop.LastName).HasColumnName("last_name").HasMaxLength(255);
        builder.Property(prop => prop.MiddleName).HasColumnName("middle_name").HasMaxLength(255).IsRequired(false);
        builder.Property(prop => prop.PhoneNumber).HasColumnName("phone_number").HasMaxLength(255);
    }
}
