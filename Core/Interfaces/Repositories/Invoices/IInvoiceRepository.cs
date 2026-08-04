using Core.Enums;
using Core.Common;
using Core.Dtos.Invoices;

namespace Core.Interfaces.Repositories.Invoices;

public interface IInvoiceRepository
{
    Task<PagedResult<IReadOnlyCollection<InvoiceDto>>> GetInvoicesAsync(
        string medicalOrganizationCode,
        int year,
        int month,
        int page,
        int pageSize,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

}