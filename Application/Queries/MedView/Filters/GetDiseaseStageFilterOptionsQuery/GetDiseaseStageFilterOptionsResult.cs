using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiseaseStageFilterOptionsQuery;

public sealed record GetDiseaseStageFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
