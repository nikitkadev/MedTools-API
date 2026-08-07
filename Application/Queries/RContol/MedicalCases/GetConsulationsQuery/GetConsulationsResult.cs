using Core.Dtos.RControl.Workspace;

namespace Application.Queries.RContol.MedicalCases.GetConsulationsQuery;

public sealed record GetConsulationsResult(IReadOnlyCollection<ConsultationDto> Consultations);
