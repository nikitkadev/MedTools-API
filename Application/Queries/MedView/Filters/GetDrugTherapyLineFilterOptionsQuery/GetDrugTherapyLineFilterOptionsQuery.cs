using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetDrugTherapyLineFilterOptionsQuery;

public sealed record GetDrugTherapyLineFilterOptionsQuery : IRequest<Result<GetDrugTherapyLineFilterOptionsResult>>;
