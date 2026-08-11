using MediatR;
using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Commands.Users.UserRegistrationCommand;

public record UserRegistrationCommand(
    string Email,
    string Username,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber,
    UserRole Role,
    string? MiddleName) : IRequest<Result>;