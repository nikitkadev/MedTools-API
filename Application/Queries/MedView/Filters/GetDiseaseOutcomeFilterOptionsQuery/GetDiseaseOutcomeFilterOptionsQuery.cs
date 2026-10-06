using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDiseaseOutcomeFilterOptionsQuery;

public sealed record GetDiseaseOutcomeFilterOptionsQuery : IRequest<Result<GetDiseaseOutcomeFilterOptionsResult>>;
