using Core.Dtos.RControl.Workspace;

namespace Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCasesQuery;

public sealed record GetCompletedCasesResult(
    IReadOnlyCollection<CompletedCaseListItemDto> CompletedCases,
    int TotalCount);
