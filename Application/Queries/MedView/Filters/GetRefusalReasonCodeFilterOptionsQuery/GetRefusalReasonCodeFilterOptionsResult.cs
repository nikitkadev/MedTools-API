using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetRefusalReasonCodeFilterOptionsQuery;

public sealed record GetRefusalReasonCodeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
