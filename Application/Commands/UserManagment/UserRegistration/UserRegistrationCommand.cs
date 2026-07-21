using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Commands.UserManagment.UserRegistration;

public record UserRegistrationCommand(
    string Email,
    string Username,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber,
    UserRole Role,
    string? MiddleName) : IRequest<Result>;