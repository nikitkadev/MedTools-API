using Core.Dtos.RControl.Invoices;

namespace Application.Queries.RControl.Invoices.GetCompletedCasesQuery;

public sealed record GetCompletedCasesResult(
    IReadOnlyCollection<CompletedCaseListItemDto> CompletedCases,
    int TotalCount);
