using Core.Dtos.RControl.Invoices;
using Core.Common.Results;
using Core.Common.Enums;

namespace Core.Interfaces.Repositories.RControl;

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

    Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        int invoiceUid,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

}