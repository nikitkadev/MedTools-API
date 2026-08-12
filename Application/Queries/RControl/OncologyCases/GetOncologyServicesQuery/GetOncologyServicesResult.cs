using Core.Dtos.RControl.OncologyCases;

namespace Application.Queries.RControl.OncologyCases.GetOncologyServicesQuery;

public sealed record GetOncologyServicesResult(IReadOnlyCollection<OncologyServiceDto> OncologyServices);
