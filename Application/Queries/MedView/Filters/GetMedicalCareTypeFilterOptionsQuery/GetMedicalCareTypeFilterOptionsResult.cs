using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetMedicalCareTypeFilterOptionsQuery;

public sealed record GetMedicalCareTypeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
