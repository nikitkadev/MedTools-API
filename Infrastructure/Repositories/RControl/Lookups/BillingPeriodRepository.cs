using Microsoft.EntityFrameworkCore;

using Core.Enums;

using Infrastructure.Factories;
using Core.Dtos.RControl.Lookups;
using Core.Interfaces.RControl.Repositories.Lookups;

namespace Infrastructure.Repositories.RControl.Lookups;

public class BillingPeriodRepository(DbContextFactory dbContextFactory) : IBillingPeriodRepository
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
}