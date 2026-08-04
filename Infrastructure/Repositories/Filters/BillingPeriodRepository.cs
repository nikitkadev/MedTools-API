using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.Filters;
using Core.Interfaces.Repositories.Filters;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Filters;

public class BillingPeriodRepository(DbContextFactory dbContextFactory) : IBillingPeriodRepository
{
    public async Task<IReadOnlyCollection<BillingPeriodDto>> GetBillingPeriodsAsync(
        TargetDbType targetDb, 
        string medicalOrganizationCode, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var expression = "EXEC sp26_get_period @code_mo";

        var billingPeriods = await dbContext
            .Set<BillingPeriodDto>()
            .FromSqlRaw(expression, [new SqlParameter("@code_mo", medicalOrganizationCode)])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return billingPeriods;
    }
}