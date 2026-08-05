using MediatR;

using Core.Common;

namespace Application.Commands.Auth.LoginCommand;

public record LoginCommand(
    string Email,
    string Password) : IRequest<Result<LoginCommandResult>>;
