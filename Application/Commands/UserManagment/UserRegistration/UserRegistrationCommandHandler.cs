using MediatR;

using Core.Enums;
using Core.Common;
using Core.Entities;
using Core.Interfaces.Auth;
using Core.Interfaces.Repositories.Users;

namespace Application.Commands.UserManagment.UserRegistration;

public class UserRegistrationCommandHandler(
    IUserRepository userRepository,
    IPasswordHasherService passwordHasher) : IRequestHandler<UserRegistrationCommand, Result>
{
    public async Task<Result> Handle(
        UserRegistrationCommand request, 
        CancellationToken cancellationToken)
    {
        var passwordHash = passwordHasher.HashPassword(request.Password);

        var user = new User(
            request.Username,
            request.Email,
            passwordHash,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.PhoneNumber,
            request.Role,
            UserStatus.Active);

        return await userRepository.AddUserAsync(user);
    }
}