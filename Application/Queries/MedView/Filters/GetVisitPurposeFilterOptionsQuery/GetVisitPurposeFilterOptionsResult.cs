using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetVisitPurposeFilterOptionsQuery;

public sealed record GetVisitPurposeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
