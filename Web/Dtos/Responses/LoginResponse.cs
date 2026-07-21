namespace Web.Dtos.Responses;

public record LoginResponse(
    bool IsSuccess,
    string AccessToken,
    string RefreshToken,
    int Uid,
    string Email,
    string Username,
    string Role);
