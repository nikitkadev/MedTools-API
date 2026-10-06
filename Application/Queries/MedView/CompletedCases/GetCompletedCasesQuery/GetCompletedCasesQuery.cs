using MediatR;

using Core.Common.Enums;
using Core.Dtos.MedView;
using Core.Common.Results;

namespace Application.Queries.MedView.CompletedCases.GetCompletedCasesQuery;

public sealed record GetCompletedCasesQuery(
    TargetDbType TargetDb,
    CompletedCasesSearchFilters Filters,
    int Page,
    int PageSize) : IRequest<Result<GetCompletedCasesResult>>;
