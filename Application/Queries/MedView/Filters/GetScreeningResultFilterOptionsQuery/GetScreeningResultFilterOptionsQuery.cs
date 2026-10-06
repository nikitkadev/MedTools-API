using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetScreeningResultFilterOptionsQuery;

public sealed record GetScreeningResultFilterOptionsQuery : IRequest<Result<GetScreeningResultFilterOptionsResult>>;
