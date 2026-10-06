using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetHospitalizationOutcomeFilterOptionsQuery;

public sealed record GetHospitalizationOutcomeFilterOptionsQuery : IRequest<Result<GetHospitalizationOutcomeFilterOptionsResult>>;
