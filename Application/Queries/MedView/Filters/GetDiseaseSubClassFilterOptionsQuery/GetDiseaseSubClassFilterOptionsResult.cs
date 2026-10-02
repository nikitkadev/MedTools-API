using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiseaseSubClassFilterOptionsQuery;

public sealed record GetDiseaseSubClassFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
