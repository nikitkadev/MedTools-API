using Core.Dtos.RControl.CompletedCases;

namespace Application.Queries.RControl.CompletedCases.GetMedicalCasesQuery;

public sealed record GetMedicalCasesResult(IReadOnlyCollection<MedicalCaseListItemDto> MedicalCases);
