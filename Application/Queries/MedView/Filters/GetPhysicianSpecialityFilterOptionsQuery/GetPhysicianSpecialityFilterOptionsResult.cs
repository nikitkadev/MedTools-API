using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetPhysicianSpecialityFilterOptionsQuery;

public sealed record GetPhysicianSpecialityFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
