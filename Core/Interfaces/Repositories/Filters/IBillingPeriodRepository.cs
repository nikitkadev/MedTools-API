using Core.Enums;
using Core.Dtos.Filters;

namespace Core.Interfaces.Repositories.Filters;

public interface IBillingPeriodRepository
{
    Task<IReadOnlyCollection<BillingPeriodDto>> GetBillingPeriodsAsync(
        TargetDbType targetDb,
        string medicalOrganizationCode,
        CancellationToken cancellationToken);
}
