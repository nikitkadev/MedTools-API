using Core.Enums;
using Core.Dtos.RControl.ClinicalGroups;

namespace Core.Interfaces.RControl.Repositories.ClinicalGroups;

public interface IClinicalGroupRepository
{
    Task<IReadOnlyCollection<ClassificationCriterionDto>> GetClassificationCriterionsAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TreatmentComplexityCoefficientDto>> GetTreatmentComplexityCoefficientsAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
