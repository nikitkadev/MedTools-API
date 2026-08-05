using Core.Dtos.CompletedCases;

namespace Application.Queries.RContol.CompletedCases.GetCompletedCasesQuery;

public sealed record GetCompletedCasesResult(
    IReadOnlyCollection<CompletedCaseDto> CompletedCases,
    int TotalCount);
