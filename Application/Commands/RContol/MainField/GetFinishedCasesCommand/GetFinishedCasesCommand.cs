using MediatR;

using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Application.Commands.RContol.MainField.GetFinishedCasesCommand;

public record GetFinishedCasesCommand(
    int SchetUid,
    int Page,
    int PageSize,
    TargetDbType TargetDb,
    string SearchString) : IRequest<Result<FinishedCasesQueryResult>>;
