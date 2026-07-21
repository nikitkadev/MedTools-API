using MediatR;

using Core.Common;
using Core.Dtos;
using Core.Enums;

namespace Application.Commands.RContol.GetInvoicesShortlyCommand;

public record GetInvoicesShortlyCommand(
    string OrgCode,
    int Year,
    int Month,
    int Skip,
    int Take,
    TargetDbType TargetDb,
    string SearchString) : IRequest<Result<InvoicesShortlyQueryResult>>;
