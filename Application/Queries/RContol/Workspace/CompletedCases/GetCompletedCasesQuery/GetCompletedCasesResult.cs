using Core.Dtos.RControl.Workspace;

namespace Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCasesQuery;

public sealed record GetCompletedCasesResult(
    IReadOnlyCollection<CompletedCaseDto> CompletedCases,
    int TotalCount);
