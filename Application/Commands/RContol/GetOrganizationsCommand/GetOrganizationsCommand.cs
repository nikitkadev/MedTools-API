using MediatR;

using Core.Common;
using Core.Enums;
using Core.Dtos;

namespace Application.Commands.RContol.GetOrganizationsCommand;

public record GetOrganizationsCommand(
    TargetDbType TargetDb) : IRequest<Result<MedOrganizationsQueryResult>>;
