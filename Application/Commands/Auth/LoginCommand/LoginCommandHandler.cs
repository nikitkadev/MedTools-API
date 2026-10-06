using MediatR;

using Core.Common.Results;
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

        var passwordMatch = passwordHasher.VerifyPassword(
            request.Password, 
            user.PasswordHash);

        if (!passwordMatch)
        {
            return Result<LoginCommandResult>.Failure("Неверный логин или пароль");
        }

        var accessToken = generationService.GenerateAccessToken(user);

        var response = new LoginCommandResult(
            AccessToken: accessToken,
            Uid: user.Id,
            Email: user.Email,
            Username: user.Username);

        return Result<LoginCommandResult>.Success(response);
    }
}