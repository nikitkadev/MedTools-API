using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.Invoices.GetCompletedCasesQuery;

public sealed record GetCompletedCasesQuery(
    int InvoiceUid,
    int Page,
    int PageSize,
    TargetDbType TargetDb) : IRequest<Result<GetCompletedCasesResult>>; 
