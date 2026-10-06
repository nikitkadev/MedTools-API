using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDiseaseSubClassFilterOptionsQuery;

public sealed class GetDiseaseSubClassFilterOptionsQuery : IRequest<Result<GetDiseaseSubClassFilterOptionsResult>>;
