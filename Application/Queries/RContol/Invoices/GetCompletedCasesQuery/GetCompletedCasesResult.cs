using Core.Dtos.RControl.Invoices;

namespace Application.Queries.RContol.Invoices.GetCompletedCasesQuery;

public sealed record GetCompletedCasesResult(
    IReadOnlyCollection<CompletedCaseListItemDto> CompletedCases,
    int TotalCount);
