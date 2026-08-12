using Core.Dtos.RControl.Invoices;

namespace Application.Queries.RControl.Invoices.GetInvoicesQuery;

public sealed record GetInvoicesResult(
    IReadOnlyCollection<InvoiceListItemDto> Invoices,
    int RecordsCount);
