using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetHighTechCareFilterOptionsQuery;

public sealed record GetHighTechCareFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
