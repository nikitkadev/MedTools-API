using MediatR;

using Core.Common.Results;
using Core.Common.Enums;

namespace Application.Queries.RControl.Lookups.GetBillingPeriodsQuery;

public sealed record GetBillingPeriodsQuery(
    string MedicalOrganizationCode, 
    TargetDbType TargetDb) : IRequest<Result<GetBillingPeriodsResult>>;
