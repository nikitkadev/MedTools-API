using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetReferralTypeFilterOptionsQuery;

public sealed record GetReferralTypeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
