using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.Invoices.GetCompletedCasesQuery;

public sealed record GetCompletedCasesQuery(
    int InvoiceUid,
    int Page,
    int PageSize,
    string SearchString,
    TargetDbType TargetDb) : IRequest<Result<GetCompletedCasesResult>>; 
