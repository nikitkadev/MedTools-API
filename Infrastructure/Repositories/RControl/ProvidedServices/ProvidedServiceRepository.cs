using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.ProvidedServices;
using Core.Interfaces.RControl.Repositories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.ProvidedServices;

public class ProvidedServiceRepository(
    DbContextFactory dbContextFactory) : IProvidedServiceRepository
{
    public async Task<IReadOnlyCollection<ProvidedServiceListItemDto>> GetProvidedServicesAsync(
        int medicalCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var providedServices = await dbContext
            .Set<ProvidedServiceListItemDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_provided_services @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return providedServices;
    }

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