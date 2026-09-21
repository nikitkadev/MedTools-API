using Core.Common.Results;
using MediatR;

namespace Application.Queries.MedView.Filters.GetDiseaseStageFilterOptionsQuery;

public sealed record GetDiseaseStageFilterOptionsQuery : IRequest<Result<GetDiseaseStageFilterOptionsResult>>;
