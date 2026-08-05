using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Interfaces.Repositories.MedicalCases;

using Infrastructure.Factories;
using Core.Dtos.RControl.Workspace;

namespace Infrastructure.Repositories.MedicalCases;

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