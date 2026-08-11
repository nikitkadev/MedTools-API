using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RContol.MedicalCases.GetPrescriptionsQuery;

public sealed record GetPrescriptionsResult(IReadOnlyCollection<PrescriptionDto> Prescriptions);
