using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetVisitPlaceFilterOptionsQuery;

public sealed record GetVisitPlaceFilterOptionsQuery : IRequest<Result<GetVisitPlaceFilterOptionsResult>>;
