using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetSurgicalTreatmentTypeFilterOptionsQuery;

public sealed record GetSurgicalTreatmentTypeFilterOptionsQuery : IRequest<Result<GetSurgicalTreatmentTypeFilterOptionsResult>>;
