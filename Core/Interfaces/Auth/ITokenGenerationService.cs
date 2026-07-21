using Core.Entities;

namespace Core.Interfaces.Auth;

public interface ITokenGenerationService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
