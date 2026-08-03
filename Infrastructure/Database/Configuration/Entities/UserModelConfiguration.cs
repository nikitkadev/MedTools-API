using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Database.Enitites.Auth;

namespace Infrastructure.Database.Configuration.Entities;

public class UserModelConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid").ValueGeneratedOnAdd();
        builder.Property(prop => prop.Username).HasColumnName("username").HasMaxLength(255);
        builder.Property(prop => prop.Email).HasColumnName("email").HasMaxLength(255);
        builder.Property(prop => prop.PasswordHash).HasColumnName("password_hash").HasMaxLength(255);
        builder.Property(prop => prop.FirstName).HasColumnName("name").HasMaxLength(255);
        builder.Property(prop => prop.LastName).HasColumnName("last_name").HasMaxLength(255);
        builder.Property(prop => prop.MiddleName).HasColumnName("middle_name").HasMaxLength(255).IsRequired(false);
        builder.Property(prop => prop.PhoneNumber).HasColumnName("phone_number").HasMaxLength(255);
        builder.Property(prop => prop.Role).HasColumnName("role").HasMaxLength(30);
        builder.Property(prop => prop.Status).HasColumnName("status").HasMaxLength(30);
        builder.Property(prop => prop.RefreshToken).HasColumnName("refresh_token").HasMaxLength(255);
        builder.Property(prop => prop.RefreshTokenExpiry).HasColumnName("refresh_token_expiry");
    }
}
