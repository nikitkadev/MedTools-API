namespace Application.Commands.Auth.Login;

public record LoginCommandResult(
    string AccessToken,
    string RefreshToken,
    int Uid,
    string Email,
    string Username,
    string Role);
