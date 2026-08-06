using Core.Common;
using Core.Dtos.RControl.Workspace;
using Core.Enums;

namespace Core.Interfaces.RControl.Repositories.Workspace;

public interface ICompletedCaseRepository
{
    Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        int invoiceUid,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
