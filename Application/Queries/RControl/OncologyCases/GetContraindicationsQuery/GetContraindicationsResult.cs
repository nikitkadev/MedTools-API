using Core.Dtos.RControl.OncologyCases;

namespace Application.Queries.RControl.OncologyCases.GetContraindicationsQuery;

public sealed record GetContraindicationsResult(IReadOnlyCollection<ContraindicationDto> Contraindications);
