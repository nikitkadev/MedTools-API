using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Core.Entities;
using Core.Interfaces.Auth;

using Infrastructure.Options;

namespace Infrastructure.Implementations.Services;

public class TokenGenerationService(
    IOptions<JwtSettings> options) : ITokenGenerationService
{
    public string GenerateAccessToken(User user)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.MobilePhone, user.PhoneNumber)
        };

        var jwt = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(options.Value.ExpirationInMinutes)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret)), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public string GenerateRefreshToken()
    {
        return "123123";
    }
}