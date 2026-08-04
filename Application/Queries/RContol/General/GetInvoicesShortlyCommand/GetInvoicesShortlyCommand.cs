using MediatR;

using Core.Common;
using Core.Dtos;
using Core.Enums;

namespace Application.Queries.RContol.General.GetInvoicesShortlyCommand;

public record GetInvoicesShortlyCommand(
    string OrgCode,
    int Year,
    int Month,
    int Page,
    int PageSize,
    TargetDbType TargetDb,
    string SearchString) : IRequest<Result<InvoicesShortlyQueryResult>>;
