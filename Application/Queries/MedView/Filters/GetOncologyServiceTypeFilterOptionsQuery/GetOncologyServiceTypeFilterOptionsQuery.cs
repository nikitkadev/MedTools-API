using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetOncologyServiceTypeFilterOptionsQuery;

public sealed record GetOncologyServiceTypeFilterOptionsQuery : IRequest<Result<GetOncologyServiceTypeFilterOptionsResult>>;
