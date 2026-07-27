using MediatR;

using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Application.Commands.RContol.GetCasesCommand;

public record GetCasesCommand(
    int ZSlUid,
    TargetDbType TargetDb) : IRequest<Result<CasesQueryResult>>;
