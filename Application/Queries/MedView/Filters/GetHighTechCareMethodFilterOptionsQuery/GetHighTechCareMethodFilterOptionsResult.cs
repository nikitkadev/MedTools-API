using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetHighTechCareMethodFilterOptionsQuery;

public sealed record GetHighTechCareMethodFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
