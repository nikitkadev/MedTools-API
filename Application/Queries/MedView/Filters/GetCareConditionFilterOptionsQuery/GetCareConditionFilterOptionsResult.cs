using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetCareConditionFilterOptionsQuery;

public sealed record GetCareConditionFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
