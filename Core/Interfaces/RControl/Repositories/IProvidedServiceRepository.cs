using Core.Enums;
using Core.Dtos.RControl.ProvidedServices;

namespace Core.Interfaces.RControl.Repositories;

public interface IProvidedServiceRepository
{
    Task<IReadOnlyCollection<ProvidedServiceListItemDto>> GetProvidedServicesAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<MedicalDeviceDto>> GetMedicalDevicesAsync(
        int providedServiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
