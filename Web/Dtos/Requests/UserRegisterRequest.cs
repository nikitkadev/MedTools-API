namespace Web.Dtos.Requests;

public record UserRegisterRequest(
    string Email,
    string Username,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string? MiddleName = null);