using MediatR;

using Core.Common;
using Core.Enums;

namespace Application.Queries.RContol.CompletedCases.GetCompletedCasesQuery;

public sealed record GetCompletedCasesQuery(
    int InvoiceUid,
    int Page,
    int PageSize,
    TargetDbType TargetDb) : IRequest<Result<GetCompletedCasesResult>>; 
