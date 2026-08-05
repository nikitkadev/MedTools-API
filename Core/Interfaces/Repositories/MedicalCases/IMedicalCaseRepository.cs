using Core.Enums;
using Core.Dtos.RControl.Workspace;

namespace Core.Interfaces.Repositories.MedicalCases;

public interface IMedicalCaseRepository
{
    Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
