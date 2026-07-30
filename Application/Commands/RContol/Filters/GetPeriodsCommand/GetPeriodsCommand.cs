using MediatR;

using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Application.Commands.RContol.Filters.GetPeriodsCommand;

public record GetPeriodsCommand(
    TargetDbType TargetDbType,
    string OrgCode) : IRequest<Result<BillingPeriodsQueryResult>>;
