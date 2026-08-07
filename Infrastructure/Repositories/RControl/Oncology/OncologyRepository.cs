using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.Categories.Oncology;
using Core.Interfaces.RControl.Repositories.Oncology;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.Oncology;

public class OncologyRepository(
    DbContextFactory dbContextFactory) : IOncologyRepository
{
    public async Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<OncologyCaseDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_oncology_case @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var oncologyCase = result.FirstOrDefault();

        return oncologyCase;
    }
}
