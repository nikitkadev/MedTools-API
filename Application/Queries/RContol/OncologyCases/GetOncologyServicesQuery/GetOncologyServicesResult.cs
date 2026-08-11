using Core.Dtos.RControl.OncologyCases;

namespace Application.Queries.RContol.OncologyCases.GetOncologyServicesQuery;

public sealed record GetOncologyServicesResult(IReadOnlyCollection<OncologyServiceDto> OncologyServices);
