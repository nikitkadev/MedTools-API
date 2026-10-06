using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetReferralTypeFilterOptionsQuery;

public sealed record GetReferralTypeFilterOptionsQuery : IRequest<Result<GetReferralTypeFilterOptionsResult>>;
