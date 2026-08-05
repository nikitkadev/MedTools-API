using MediatR;

using Core.Common;
using Core.Interfaces.Auth;
using Core.Interfaces.Repositories.Users;

namespace Application.Commands.Auth.LoginCommand;

public class LoginCommandHandler(
    ITokenGenerationService generationService,
    IPasswordHasherService passwordHasher,
    IUserRepository userRepository) : IRequestHandler<LoginCommand, Result<LoginCommandResult>>
{
    public async Task<Result<LoginCommandResult>> Handle(
        LoginCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await userRepository.GetUserByEmail(request.Email);
        if (!result.IsSuccess)
        {
            return Result<LoginCommandResult>.Failure(result.Error);
        }

        var user = result.Value!;

        if (!user.CanLogin())
        {
            return Result<LoginCommandResult>.Failure("Ваша учетная запись отключена, либо заблокирована");
        }

        var passwordMatch = passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
        if (!passwordMatch)
        {
            return Result<LoginCommandResult>.Failure("Неверный логин или пароль");
        }

        var accessToken = generationService.GenerateAccessToken(user);
        var refreshToken = generationService.GenerateRefreshToken();

        user.SetRefreshToken(refreshToken);

        var response = new LoginCommandResult(
            AccessToken: accessToken,
            RefreshToken: refreshToken,
            Uid: user.Uid,
            Email: user.Email,
            Username: user.Username,
            Role: user.Role.ToString());

        return Result<LoginCommandResult>.Success(response);
    }
}