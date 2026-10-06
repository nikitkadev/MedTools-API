using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiseaseFilterOptionsQuery;

public sealed record GetDiseaseFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
