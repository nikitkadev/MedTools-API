using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDiseaseClassFilterOptionsQuery;

public sealed class GetDiseaseClassFilterOptionsQuery : IRequest<Result<GetDiseaseClassFilterOptionsResult>>;
