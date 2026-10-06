using Core.Common.Enums;
using Core.Common.Results;
using Core.Dtos.RControl.Invoices;

namespace Core.Interfaces.Repositories.RControl;

public interface IInvoiceRepository
{
    Task<PagedResult<InvoiceListItemDto>> GetInvoiceListItemsAsync(
        string medicalOrganizationCode,
        int year,
        int month,
        int page,
        int pageSize,
        string searchString,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<InvoiceSummaryDto?> GetInvoiceSummaryAsync(
        int invoiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        int invoiceUid,
        int page,
        int pageSize,
        string searchString,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

}