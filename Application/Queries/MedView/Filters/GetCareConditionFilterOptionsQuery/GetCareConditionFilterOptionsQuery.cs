using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetCareConditionFilterOptionsQuery;

public sealed record GetCareConditionFilterOptionsQuery : IRequest<Result<GetCareConditionFilterOptionsResult>>;
