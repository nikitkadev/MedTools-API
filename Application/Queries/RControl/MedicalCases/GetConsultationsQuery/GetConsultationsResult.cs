using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RControl.MedicalCases.GetConsultationsQuery;

public sealed record GetConsultationsResult(IReadOnlyCollection<ConsultationDto> Consultations);
