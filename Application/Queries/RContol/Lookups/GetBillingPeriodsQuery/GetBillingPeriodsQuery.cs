using MediatR;

using Core.Enums;
using Core.Common;

namespace Application.Queries.RContol.Filters.GetBillingPeriodsQuery;

public sealed record GetBillingPeriodsQuery(
    string MedicalOrganizationCode, 
    TargetDbType TargetDb) : IRequest<Result<GetBillingPeriodsResult>>;
