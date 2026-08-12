using Core.Common.Enums;
using Core.Dtos.RControl.ClinicalGroups;

namespace Core.Interfaces.Repositories.RControl;

public interface IClinicalGroupRepository
{
    Task<IReadOnlyCollection<ClassificationCriterionDto>> GetClassificationCriteriaAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TreatmentComplexityCoefficientDto>> GetTreatmentComplexityCoefficientsAsync(
        int clinicalGroupUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
