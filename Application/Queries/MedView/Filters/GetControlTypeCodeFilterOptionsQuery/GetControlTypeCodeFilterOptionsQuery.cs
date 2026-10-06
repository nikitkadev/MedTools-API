using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetControlTypeCodeFilterOptionsQuery;

public sealed record GetControlTypeCodeFilterOptionsQuery : IRequest<Result<GetControlTypeCodeFilterOptionsResult>>;
