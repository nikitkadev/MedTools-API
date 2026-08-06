using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.Workspace;
using Core.Interfaces.RControl.Repositories.Workspace;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.Workspace;

public class MedicalCaseRepository(
    DbContextFactory dbContextFactory) : IMedicalCaseRepository
{
    public async Task<IReadOnlyCollection<MedicalCaseListItemDto>> GetMedicalCaseListItemsAsync(
        int completedCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalCases = await dbContext
            .Set<MedicalCaseListItemDto>()
            .FromSqlInterpolated($"EXEC sp26_get_sl_data @zSlUid={completedCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalCases;
    }

}