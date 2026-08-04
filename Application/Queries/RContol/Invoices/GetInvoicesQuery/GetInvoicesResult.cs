using Core.Dtos.Invoices;

namespace Application.Queries.RContol.Invoices.GetInvoicesQuery;

public sealed record GetInvoicesResult(
    IReadOnlyCollection<InvoiceDto> Invoices,
    int RecordsCount);
