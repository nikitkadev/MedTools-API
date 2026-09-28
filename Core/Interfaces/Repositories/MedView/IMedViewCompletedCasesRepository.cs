using Core.Common.Enums;
using Core.Common.Results;
using Core.Dtos.MedView;
using Core.Dtos.RControl.Invoices;

namespace Core.Interfaces.Repositories.MedView;

public interface IMedViewCompletedCasesRepository
{
    Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        TargetDbType targetDb,
        CompletedCasesSearchFilters filters,
        CancellationToken cancellationToken = default);
}
