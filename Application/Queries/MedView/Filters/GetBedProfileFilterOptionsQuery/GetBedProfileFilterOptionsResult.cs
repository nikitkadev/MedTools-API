using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetBedProfileFilterOptionsQuery;

public sealed record GetBedProfileFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
