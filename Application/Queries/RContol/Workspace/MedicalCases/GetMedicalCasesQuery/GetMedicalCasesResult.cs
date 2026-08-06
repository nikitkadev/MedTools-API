using Core.Dtos.RControl.Workspace;

namespace Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCasesQuery;

public sealed record GetMedicalCasesResult(IReadOnlyCollection<MedicalCaseListItemDto> MedicalCases);
