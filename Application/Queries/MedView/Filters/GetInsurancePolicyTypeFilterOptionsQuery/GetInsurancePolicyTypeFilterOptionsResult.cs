using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetInsurancePolicyTypeFilterOptionsQuery;

public sealed record GetInsurancePolicyTypeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
