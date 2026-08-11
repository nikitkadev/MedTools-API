using Core.Common.Enums;
using Core.Dtos.RControl.Medications;

namespace Core.Interfaces.Repositories.RControl;

public interface IMedicationRepository
{
    Task<IReadOnlyCollection<InjectionDateDto>> GetInjectionDatesAsync(
        int medicationUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<InjectionDto>> GetInjectionsAsync(
        int medicationUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
