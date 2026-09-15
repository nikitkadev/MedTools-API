using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed record GetInsuranceFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
