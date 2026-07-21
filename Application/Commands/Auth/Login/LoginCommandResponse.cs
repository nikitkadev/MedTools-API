namespace Application.Commands.Auth.Login;

public record LoginCommandResponse(
    string AccessToken,
    string RefreshToken,
    int Uid,
    string Email,
    string Username,
    string Role);
