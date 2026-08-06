using Microsoft.EntityFrameworkCore;

using Core.Enums;

using Infrastructure.Factories;
using Core.Dtos.RControl.Workspace;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Infrastructure.Repositories.RControl.Workspace;

public class MedicalCaseRepository(
    DbContextFactory dbContextFactory) : IMedicalCaseRepository
{
    public async Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalCases = await dbContext
            .Set<MedicalCaseDto>()
            .FromSqlInterpolated($"EXEC sp26_get_sl_data @zSlUid={completedCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalCases;
    }

}