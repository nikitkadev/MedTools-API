namespace Application.Commands.Auth.LoginCommand;

public record LoginCommandResult(
    string AccessToken,
    int Uid,
    string Email,
    string Username);
