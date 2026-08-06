using Core.Enums;
using Core.Dtos.RControl.Lookups;

namespace Core.Interfaces.RControl.Repositories.Lookups;

public interface IBillingPeriodRepository
{
    Task<IReadOnlyCollection<BillingPeriodDto>> GetBillingPeriodsAsync(
        TargetDbType targetDb,
        string medicalOrganizationCode,
        CancellationToken cancellationToken);
}
