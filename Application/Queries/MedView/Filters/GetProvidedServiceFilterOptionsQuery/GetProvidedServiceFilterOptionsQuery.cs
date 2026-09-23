using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetProvidedServiceFilterOptionsQuery;

public sealed record GetProvidedServiceFilterOptionsQuery : IRequest<Result<GetProvidedServiceFilterOptionsResult>>;
