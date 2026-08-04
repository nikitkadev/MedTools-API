using MediatR;

using Core.Common;

namespace Application.Commands.Auth.Login;

public record LoginCommand(
    string Email,
    string Password) : IRequest<Result<LoginCommandResult>>;
