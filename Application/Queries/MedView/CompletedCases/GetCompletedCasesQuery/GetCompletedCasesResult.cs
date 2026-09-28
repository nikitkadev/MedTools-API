using Core.Dtos.RControl.Invoices;

namespace Application.Queries.MedView.CompletedCases.GetCompletedCasesQuery;

public sealed record GetCompletedCasesResult(
    IReadOnlyCollection<CompletedCaseListItemDto> CompletedCaseListItems,
    int TotalCount);
