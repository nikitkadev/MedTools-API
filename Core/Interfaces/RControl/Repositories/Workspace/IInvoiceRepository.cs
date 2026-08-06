using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Workspace;

namespace Core.Interfaces.RControl.Repositories.Workspace;

public interface IInvoiceRepository
{
    Task<PagedResult<InvoiceDto>> GetInvoicesAsync(
        string medicalOrganizationCode,
        int year,
        int month,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    InvoiceSummaryDto? GetInvoiceSummary(
        int invoiceUid,
        TargetDbType targetDb);

}