using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiseaseClassFilterOptionsQuery;

public sealed record GetDiseaseClassFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
