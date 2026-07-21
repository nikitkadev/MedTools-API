namespace Core.Interfaces.Auth;

public interface IPasswordHasherService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string storedHash);
}
