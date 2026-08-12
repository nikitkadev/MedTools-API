using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RControl.MedicalCases.GetMedicalSanctionsQuery;

public sealed record GetMedicalSanctionsResult(IReadOnlyCollection<MedicalSanctionDto> MedicalSanctions);
