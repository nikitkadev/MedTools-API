using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetProvidedServiceFilterOptionsQuery;

public sealed record GetProvidedServiceFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
