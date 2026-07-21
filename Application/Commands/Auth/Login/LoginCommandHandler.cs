using MediatR;

using Core.Common;
using Core.Interfaces.Auth;
using Core.Interfaces.Repositories;

namespace Application.Commands.Auth.Login;

public class LoginCommandHandler(
    ITokenGenerationService generationService,
    IPasswordHasherService passwordHasher,
    IUserRepository userRepository) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(
        LoginCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await userRepository.GetUserByEmail(request.Email);
        if (!result.IsSuccess)
        {
            return Result<LoginCommandResponse>.Failure(result.Error);
        }

        var user = result.Value!;

        if (!user.CanLogin())
        {
            return Result<LoginCommandResponse>.Failure("Ваша учетная запись отключена, либо заблокирована");
        }

        var passwordMatch = passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
        if (!passwordMatch)
        {
            return Result<LoginCommandResponse>.Failure("Неверный логин или пароль");
        }

        var accessToken = generationService.GenerateAccessToken(user);
        var refreshToken = generationService.GenerateRefreshToken();

        user.SetRefreshToken(refreshToken);

        var response = new LoginCommandResponse(
            AccessToken: accessToken,
            RefreshToken: refreshToken,
            Uid: user.Uid,
            Email: user.Email,
            Username: user.Username,
            Role: user.Role.ToString());

        return Result<LoginCommandResponse>.Success(response);
    }
}