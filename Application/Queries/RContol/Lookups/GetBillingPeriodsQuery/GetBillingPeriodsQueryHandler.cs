using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.Lookups.GetBillingPeriodsQuery;

public class GetBillingPeriodsQueryHandler(
    ILookupsRepository lookupsRepository) : IRequestHandler<GetBillingPeriodsQuery, Result<GetBillingPeriodsResult>>
{
    public async Task<Result<GetBillingPeriodsResult>> Handle(
        GetBillingPeriodsQuery request, 
        CancellationToken cancellationToken)
    {
        var billingPeriods = await lookupsRepository.GetBillingPeriodsAsync(
            targetDb: request.TargetDb,
            medicalOrganizationCode: request.MedicalOrganizationCode,
            cancellationToken: cancellationToken);

        return Result<GetBillingPeriodsResult>.Success(
            new GetBillingPeriodsResult(
                BillingPeriods: billingPeriods));

    }
}