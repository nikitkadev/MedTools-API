using Core.Common.Enums;
using Core.Dtos.RControl.CompletedCases;

namespace Core.Interfaces.Repositories.RControl;

public interface ICompletedCaseRepository
{
    Task<IReadOnlyCollection<MedicalCaseListItemDto>> GetMedicalCaseListItemsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<CompletedCaseDetailsDto?> GetCompletedCaseDetailsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

}