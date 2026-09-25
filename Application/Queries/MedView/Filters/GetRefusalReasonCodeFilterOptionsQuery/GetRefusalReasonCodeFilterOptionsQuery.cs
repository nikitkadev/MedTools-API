using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetRefusalReasonCodeFilterOptionsQuery;

public sealed record GetRefusalReasonCodeFilterOptionsQuery(string Search) : IRequest<Result<GetRefusalReasonCodeFilterOptionsResult>>;
