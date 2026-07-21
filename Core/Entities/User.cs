using Core.Enums;

namespace Core.Entities;

public class User(
    string username,
    string email,
    string passwordHash,
    string firstName,
    string lastName,
    string? middleName,
    string phoneNumber,
    UserRole role,
    UserStatus status)
{
    public int Uid { get; private set; }
    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string PasswordHash { get; private set; } = passwordHash;
    public string? RefreshToken { get; private set; } 

    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string? MiddleName { get; private set; } = middleName;
    public string PhoneNumber { get; private set; } = phoneNumber;

    public UserRole Role { get; private set; } = role;
    public UserStatus Status { get; private set; } = status;

    public bool CanLogin() => Status == UserStatus.Active;
    public void SetRefreshToken(string refreshToken) => RefreshToken = refreshToken; 
}
