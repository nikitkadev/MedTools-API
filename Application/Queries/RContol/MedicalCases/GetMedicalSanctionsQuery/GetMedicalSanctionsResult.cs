using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RContol.MedicalCases.GetMedicalSanctionsQuery;

public sealed record GetMedicalSanctionsResult(IReadOnlyCollection<MedicalSanctionDto> MedicalSanctions);
