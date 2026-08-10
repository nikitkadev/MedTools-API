using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.ClinicalGroups;
using Core.Interfaces.RControl.Repositories.ClinicalGroups;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.ClinicalGroups;

public class ClinicalGroupRepository(
    DbContextFactory dbContextFactory) : IClinicalGroupRepository
{
    public async Task<IReadOnlyCollection<ClassificationCriterionDto>> GetClassificationCriterionsAsync(
        int clinicalGroupUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var classificationCriterions = await dbContext
            .Set<ClassificationCriterionDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_classification_criterions @pClinicalGroupUid={clinicalGroupUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return classificationCriterions;
    }
}