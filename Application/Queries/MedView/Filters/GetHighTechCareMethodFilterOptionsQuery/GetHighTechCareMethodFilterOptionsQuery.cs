using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetHighTechCareMethodFilterOptionsQuery;

public sealed record GetHighTechCareMethodFilterOptionsQuery(string Search) : IRequest<Result<GetHighTechCareMethodFilterOptionsResult>>;
