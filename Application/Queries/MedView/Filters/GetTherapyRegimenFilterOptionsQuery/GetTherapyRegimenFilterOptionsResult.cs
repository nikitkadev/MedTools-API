using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetTherapyRegimenFilterOptionsQuery;

public sealed record GetTherapyRegimenFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
