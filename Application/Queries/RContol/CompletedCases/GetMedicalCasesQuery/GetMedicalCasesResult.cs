using Core.Dtos.RControl.CompletedCases;

namespace Application.Queries.RContol.CompletedCases.GetMedicalCasesQuery;

public sealed record GetMedicalCasesResult(IReadOnlyCollection<MedicalCaseListItemDto> MedicalCases);
