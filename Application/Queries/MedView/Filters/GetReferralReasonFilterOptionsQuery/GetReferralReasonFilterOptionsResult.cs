using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetReferralReasonFilterOptionsQuery;

public sealed record GetReferralReasonFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
