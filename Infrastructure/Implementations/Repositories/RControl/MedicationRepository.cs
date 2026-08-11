using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.Medications;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class MedicationRepository(
    DbContextFactory dbContextFactory) : IMedicationRepository
{
    public async Task<IReadOnlyCollection<InjectionDateDto>> GetInjectionDatesAsync(
        int medicationUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var injectionDates = await dbContext
            .Set<InjectionDateDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_injection_dates @pMedicationUid={medicationUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return injectionDates;
    }

    public async Task<IReadOnlyCollection<InjectionDto>> GetInjectionsAsync(
        int medicationUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var injections = await dbContext
            .Set<InjectionDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_injections @pMedicationUid={medicationUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return injections;
    }

}
