using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RContol.MedicalCases.GetConsultationsQuery;

public sealed record GetConsultationsResult(IReadOnlyCollection<ConsultationDto> Consultations);
