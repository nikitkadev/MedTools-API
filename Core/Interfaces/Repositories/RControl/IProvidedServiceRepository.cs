using Core.Common.Enums;
using Core.Dtos.RControl.ProvidedServices;

namespace Core.Interfaces.Repositories.RControl;

public interface IProvidedServiceRepository
{
    Task<IReadOnlyCollection<MedicalDeviceDto>> GetMedicalDevicesAsync(
        int providedServiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
