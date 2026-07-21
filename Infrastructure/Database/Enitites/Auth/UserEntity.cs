namespace Infrastructure.Database.Enitites.Auth;

public class UserEntity
{
    public int Uid { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get;set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; 

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
}