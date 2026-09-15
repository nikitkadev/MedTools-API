using MediatR;

using Core.Common.Enums;
using Core.Common.Results;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed record GetInsuranceFilterOptionsQuery(TargetDbType TargetDb) : IRequest<Result<GetInsuranceFilterOptionsResult>>;

