using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetRefusalReasonCodeFilterOptionsQuery;

public sealed record GetRefusalReasonCodeFilterOptionsQuery : IRequest<Result<GetRefusalReasonCodeFilterOptionsResult>>;
