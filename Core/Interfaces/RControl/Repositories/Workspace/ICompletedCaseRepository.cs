using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Workspace;
using Core.Dtos.RControl.Categories.MedicalCase;

namespace Core.Interfaces.RControl.Repositories.Workspace;

public interface ICompletedCaseRepository
{
    Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        int invoiceUid,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<CompletedCaseDetailsDto?> GetCompletedCaseDetailsAsync(
        int completedCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
