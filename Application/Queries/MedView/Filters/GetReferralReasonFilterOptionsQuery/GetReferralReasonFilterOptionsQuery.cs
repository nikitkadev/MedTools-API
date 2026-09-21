using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetReferralReasonFilterOptionsQuery;

public sealed record GetReferralReasonFilterOptionsQuery : IRequest<Result<GetReferralReasonFilterOptionsResult>>;
