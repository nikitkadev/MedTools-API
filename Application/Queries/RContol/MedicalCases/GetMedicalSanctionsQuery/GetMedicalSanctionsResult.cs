using Core.Dtos.RControl.Categories.MedicalCase;

namespace Application.Queries.RContol.MedicalCases.GetMedicalSanctionsQuery;

public sealed record GetMedicalSanctionsResult(IReadOnlyCollection<MedicalSanctionDto> MedicalSanctions);
