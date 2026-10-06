using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetVisitPlaceFilterOptionsQuery;

public sealed record GetVisitPlaceFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
