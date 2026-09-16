using Core.Common.Results;
using MediatR;

namespace Application.Queries.MedView.Filters.GetCareFormFilterOptionsQuery;

public sealed record GetCareFormFilterOptionsQuery : IRequest<Result<GetCareFormFilterOptionsResult>>;
