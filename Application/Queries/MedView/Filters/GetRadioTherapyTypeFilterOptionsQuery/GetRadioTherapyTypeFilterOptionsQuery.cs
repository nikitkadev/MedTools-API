using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetRadioTherapyTypeFilterOptionsQuery;

public sealed record GetRadioTherapyTypeFilterOptionsQuery : IRequest<Result<GetRadioTherapyTypeFilterOptionsResult>>;
