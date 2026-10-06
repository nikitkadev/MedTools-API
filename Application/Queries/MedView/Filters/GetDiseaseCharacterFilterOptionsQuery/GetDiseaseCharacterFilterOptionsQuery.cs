using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDiseaseCharacterFilterOptionsQuery;

public sealed record GetDiseaseCharacterFilterOptionsQuery : IRequest<Result<GetDiseaseCharacterFilterOptionsResult>>;
