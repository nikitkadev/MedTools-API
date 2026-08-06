using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Workspace;

namespace Core.Interfaces.RControl.Repositories.Workspace;

public interface IInvoiceRepository
{
    Task<PagedResult<InvoiceListItemDto>> GetInvoiceListItemsAsync(
        string medicalOrganizationCode,
        int year,
        int month,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<InvoiceSummaryDto?> GetInvoiceSummaryAsync(
        int invoiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

}