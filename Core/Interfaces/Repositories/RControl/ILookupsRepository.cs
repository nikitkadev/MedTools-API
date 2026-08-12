using Core.Common.Enums;
using Core.Dtos.RControl.Lookups;

namespace Core.Interfaces.Repositories.RControl;

public interface ILookupsRepository
{
    Task<IReadOnlyCollection<BillingPeriodDto>> GetBillingPeriodsAsync(
        TargetDbType targetDb,
        string medicalOrganizationCode,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
