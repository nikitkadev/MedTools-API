using MediatR;

using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetInsurancePolicyTypeFilterOptionsQuery;

public sealed record GetInsurancePolicyTypeFilterOptionsQuery : IRequest<Result<GetInsurancePolicyTypeFilterOptionsResult>>;