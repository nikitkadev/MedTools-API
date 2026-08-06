using Core.Enums;
using Core.Dtos.RControl.Workspace;

namespace Core.Interfaces.RControl.Repositories.Workspace;

public interface IMedicalCaseRepository
{
    Task<IReadOnlyCollection<MedicalCaseListItemDto>> GetMedicalCaseListItemsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
