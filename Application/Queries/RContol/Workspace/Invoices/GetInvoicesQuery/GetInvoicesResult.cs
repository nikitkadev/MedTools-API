using Core.Dtos.RControl.Workspace;

namespace Application.Queries.RContol.Workspace.Invoices.GetInvoicesQuery;

public sealed record GetInvoicesResult(
    IReadOnlyCollection<InvoiceListItemDto> Invoices,
    int RecordsCount);
