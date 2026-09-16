using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetCareFormFilterOptionsQuery;

public sealed record GetCareFormFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
