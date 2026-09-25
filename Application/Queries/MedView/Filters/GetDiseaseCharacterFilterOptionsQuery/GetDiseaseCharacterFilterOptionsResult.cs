using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiseaseCharacterFilterOptionsQuery;

public sealed record GetDiseaseCharacterFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
