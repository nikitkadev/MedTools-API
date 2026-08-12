using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RControl.MedicalCases.GetPrescriptionsQuery;

public sealed record GetPrescriptionsResult(IReadOnlyCollection<PrescriptionDto> Prescriptions);
