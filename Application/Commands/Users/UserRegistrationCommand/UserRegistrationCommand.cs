using MediatR;

using Core.Common.Results;

namespace Application.Commands.Users.UserRegistrationCommand;

public record UserRegistrationCommand(
    string Email,
    string Username,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string? MiddleName) : IRequest<Result>;