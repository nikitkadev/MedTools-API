using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetOncologyServiceTypeFilterOptionsQuery;

public sealed record GetOncologyServiceTypeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
