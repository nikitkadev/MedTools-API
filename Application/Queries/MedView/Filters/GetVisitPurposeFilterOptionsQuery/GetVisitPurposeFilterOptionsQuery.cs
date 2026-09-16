using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetVisitPurposeFilterOptionsQuery;

public sealed record GetVisitPurposeFilterOptionsQuery : IRequest<Result<GetVisitPurposeFilterOptionsResult>>;
