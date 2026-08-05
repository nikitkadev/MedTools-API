using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Invoices;

namespace Application.Queries.RContol.Workspace.Invoices.GetInvoiceSummaryQuery;

public sealed class GetInvoiceSummaryQueryHandler(
    IInvoiceRepository invoiceRepository) : IRequestHandler<GetInvoiceSummaryQuery, Result<GetInvoiceSummaryResult>>
{
    public async Task<Result<GetInvoiceSummaryResult>> Handle(
        GetInvoiceSummaryQuery request, 
        CancellationToken cancellationToken)
    {
        var invoiceSummary = invoiceRepository.GetInvoiceSummary(
            invoiceUid: request.InvoiceUid,
            targetDb: request.TargetDb);

        if(invoiceSummary is null)
        {
            return Result<GetInvoiceSummaryResult>.Failure(""); //TODO: Описать ошибку
        }

        return Result<GetInvoiceSummaryResult>.Success(
            new GetInvoiceSummaryResult(
                InvoiceSummary: invoiceSummary));
    }
}
