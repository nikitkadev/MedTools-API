using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDiseaseFilterOptionsQuery;

public sealed record GetDiseaseFilterOptionsQuery(string Search) : IRequest<Result<GetDiseaseFilterOptionsResult>>;
