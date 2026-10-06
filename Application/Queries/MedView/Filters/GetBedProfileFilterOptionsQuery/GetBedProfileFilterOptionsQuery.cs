using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetBedProfileFilterOptionsQuery;

public sealed record GetBedProfileFilterOptionsQuery : IRequest<Result<GetBedProfileFilterOptionsResult>>;
