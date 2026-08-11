using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.Lookups;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class LookupsRepository(
    DbContextFactory dbContextFactory) : ILookupsRepository
{
    public async Task<IReadOnlyCollection<BillingPeriodDto>> GetBillingPeriodsAsync(
        TargetDbType targetDb,
        string medicalOrganizationCode,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var billingPeriods = await dbContext
            .Set<BillingPeriodDto>()
            .FromSqlInterpolated($"EXEC sp26_get_period @code_mo={medicalOrganizationCode}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return billingPeriods;
    }

    public async Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
       TargetDbType targetDb,
       CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalOrganizations = await dbContext
            .Set<MedicalOrganizationDto>()
            .FromSqlRaw("EXEC sp26_get_mo")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalOrganizations;
    }

}
