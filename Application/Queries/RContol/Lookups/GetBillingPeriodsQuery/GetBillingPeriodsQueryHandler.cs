using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Lookups;

namespace Application.Queries.RContol.Lookups.GetBillingPeriodsQuery;

public class GetBillingPeriodsQueryHandler(IBillingPeriodRepository billingPeriodRepository) : IRequestHandler<GetBillingPeriodsQuery, Result<GetBillingPeriodsResult>>
{
    public async Task<Result<GetBillingPeriodsResult>> Handle(
        GetBillingPeriodsQuery request, 
        CancellationToken cancellationToken)
    {
        var billingPeriods = await billingPeriodRepository.GetBillingPeriodsAsync(
            targetDb: request.TargetDb,
            medicalOrganizationCode: request.MedicalOrganizationCode,
            cancellationToken: cancellationToken);

        return Result<GetBillingPeriodsResult>.Success(
            new GetBillingPeriodsResult(
                BillingPeriods: billingPeriods));

    }
}