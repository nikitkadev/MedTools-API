using Core.Common.Results;
using MediatR;

namespace Application.Queries.MedView.Filters.GetDrugTherapyCycleFilterOptionsQuery;

public sealed record GetDrugTherapyCycleFilterOptionsQuery : IRequest<Result<GetDrugTherapyCycleFilterOptionsResult>>;
