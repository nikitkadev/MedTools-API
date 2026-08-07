using Core.Dtos.RControl.Oncology;

namespace Application.Queries.RContol.Oncology.GetContraindicationsQuery;

public sealed record GetContraindicationsResult(IReadOnlyCollection<ContraindicationDto> Contraindications);
