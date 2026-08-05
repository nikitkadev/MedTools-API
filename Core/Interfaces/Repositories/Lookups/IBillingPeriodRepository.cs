using Core.Enums;
using Core.Dtos.Lookups;

namespace Core.Interfaces.Repositories.Lookups;

public interface IBillingPeriodRepository
{
    Task<IReadOnlyCollection<BillingPeriodDto>> GetBillingPeriodsAsync(
        TargetDbType targetDb,
        string medicalOrganizationCode,
        CancellationToken cancellationToken);
}
