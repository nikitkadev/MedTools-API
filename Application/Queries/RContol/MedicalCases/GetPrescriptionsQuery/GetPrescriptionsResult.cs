using Core.Dtos.RControl.Categories.MedicalCase;

namespace Application.Queries.RContol.MedicalCases.GetPrescriptionsQuery;

public sealed record GetPrescriptionsResult(IReadOnlyCollection<PrescriptionDto> Prescriptions);
