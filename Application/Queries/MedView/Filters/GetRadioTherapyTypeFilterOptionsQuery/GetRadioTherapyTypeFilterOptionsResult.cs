using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetRadioTherapyTypeFilterOptionsQuery;

public sealed record GetRadioTherapyTypeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
