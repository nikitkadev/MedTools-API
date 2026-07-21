namespace Web.Dtos.Requests;

public record UserLoginRequest(
    string Email,
    string Password);