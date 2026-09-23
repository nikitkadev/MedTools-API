using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetHighTechCareFilterOptionsQuery;

public sealed record GetHighTechCareFilterOptionsQuery : IRequest<Result<GetHighTechCareFilterOptionsResult>>;
