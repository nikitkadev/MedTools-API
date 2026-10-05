using Core.Common.Enums;

namespace Core.Entities;

public class User(
    string username,
    string email,
    string passwordHash,
    string firstName,
    string lastName,
    string? middleName,
    string phoneNumber)
{
    public int Id { get; private set; }

    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string PasswordHash { get; private set; } = passwordHash;

    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string? MiddleName { get; private set; } = middleName;
    public string PhoneNumber { get; private set; } = phoneNumber;
}
