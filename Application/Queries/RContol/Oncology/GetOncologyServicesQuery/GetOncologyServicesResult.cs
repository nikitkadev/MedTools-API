using Core.Dtos.RControl.Oncology;

namespace Application.Queries.RContol.Oncology.GetOncologyServicesQuery;

public sealed record GetOncologyServicesResult(IReadOnlyCollection<OncologyServiceDto> OncologyServices);
