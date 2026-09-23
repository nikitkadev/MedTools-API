using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetClinicalGroupFilterOptionsQuery;

public sealed record GetClinicalGroupFilterOptionsQuery : IRequest<Result<GetClinicalGroupFilterOptionsResult>>;
