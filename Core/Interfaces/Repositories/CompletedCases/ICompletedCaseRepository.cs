using Core.Common;
using Core.Dtos.CompletedCases;
using Core.Enums;

namespace Core.Interfaces.Repositories.CompletedCases;

public interface ICompletedCaseRepository
{
    Task<PagedResult<CompletedCaseDto>> GetCompletedCasesAsync(
        int invoiceUid,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
