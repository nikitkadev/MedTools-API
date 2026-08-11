using Core.Dtos.RControl.OncologyCases;

namespace Application.Queries.RContol.OncologyCases.GetContraindicationsQuery;

public sealed record GetContraindicationsResult(IReadOnlyCollection<ContraindicationDto> Contraindications);
