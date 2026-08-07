using Core.Dtos.RControl.Workspace;

namespace Application.Queries.RContol.MedicalCases.GetConsultationsQuery;

public sealed record GetConsultationsResult(IReadOnlyCollection<ConsultationDto> Consultations);
