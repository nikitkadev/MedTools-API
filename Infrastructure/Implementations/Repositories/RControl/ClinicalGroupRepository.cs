using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.ClinicalGroups;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class ClinicalGroupRepository(
    DbContextFactory dbContextFactory) : IClinicalGroupRepository
{
    public async Task<IReadOnlyCollection<ClassificationCriterionDto>> GetClassificationCriteriaAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var classificationCriteria = await dbContext
            .Set<ClassificationCriterionDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_classification_criteria @pClinicalGroupUid={clinicalGroupUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return classificationCriteria;
    }

    public async Task<IReadOnlyCollection<TreatmentComplexityCoefficientDto>> GetTreatmentComplexityCoefficientsAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var treatmentComplexityCoefficients = await dbContext
            .Set<TreatmentComplexityCoefficientDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_treatment_complexity_coefficients @pClinicalGroupUid={clinicalGroupUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return treatmentComplexityCoefficients;
    }
}
