using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.ProvidedServices;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class ProvidedServiceRepository(
    DbContextFactory dbContextFactory) : IProvidedServiceRepository
{
    public async Task<IReadOnlyCollection<MedicalDeviceDto>> GetMedicalDevicesAsync(
        int providedServiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalDevices = await dbContext
            .Set<MedicalDeviceDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_medical_devices @pProvidedServiceUid={providedServiceUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalDevices;
    }

}