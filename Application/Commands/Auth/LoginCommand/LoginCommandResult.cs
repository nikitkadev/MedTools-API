namespace Application.Commands.Auth.LoginCommand;

public record LoginCommandResult(
    string AccessToken,
    string RefreshToken,
    int Uid,
    string Email,
    string Username,
    string Role);
