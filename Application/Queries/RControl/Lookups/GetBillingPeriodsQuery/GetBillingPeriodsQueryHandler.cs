using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.Lookups.GetBillingPeriodsQuery;

public sealed class GetBillingPeriodsQueryHandler(
    ILookupsRepository lookupsRepository) : IRequestHandler<GetBillingPeriodsQuery, Result<GetBillingPeriodsResult>>
{
    public async Task<Result<GetBillingPeriodsResult>> Handle(
        GetBillingPeriodsQuery request, 
        CancellationToken cancellationToken)
    {
        var billingPeriods = await lookupsRepository.GetBillingPeriodsAsync(
            medicalOrganizationCode: request.MedicalOrganizationCode,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetBillingPeriodsResult>.Success(
            new GetBillingPeriodsResult(
                BillingPeriods: billingPeriods));

    }
}