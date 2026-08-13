using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.CompletedCases;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class CompletedCaseRepository(
    DbContextFactory dbContextFactory) : ICompletedCaseRepository
{

    public async Task<IReadOnlyCollection<MedicalCaseListItemDto>> GetMedicalCaseListItemsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalCases = await dbContext
            .Set<MedicalCaseListItemDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_medical_cases @pCompletedCaseUid={completedCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalCases;
    }

    public async Task<CompletedCaseDetailsDto?> GetCompletedCaseDetailsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var results = await dbContext
            .Set<CompletedCaseDetailsDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_completed_case_details @pCompletedCaseUid={completedCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var completedCaseDetails = results.FirstOrDefault();

        return completedCaseDetails;

    }
    
}