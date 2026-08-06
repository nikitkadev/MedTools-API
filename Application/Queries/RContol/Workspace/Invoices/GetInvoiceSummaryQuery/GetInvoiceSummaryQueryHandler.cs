using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.Workspace.Invoices.GetInvoiceSummaryQuery;

public sealed class GetInvoiceSummaryQueryHandler(
    IInvoiceRepository invoiceRepository) : IRequestHandler<GetInvoiceSummaryQuery, Result<GetInvoiceSummaryResult>>
{
    public async Task<Result<GetInvoiceSummaryResult>> Handle(
        GetInvoiceSummaryQuery request, 
        CancellationToken cancellationToken)
    {
        var invoiceSummary = await invoiceRepository.GetInvoiceSummaryAsync(
            invoiceUid: request.InvoiceUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if(invoiceSummary is null)
        {
            return Result<GetInvoiceSummaryResult>.Failure(""); //TODO: Описать ошибку
        }

        return Result<GetInvoiceSummaryResult>.Success(
            new GetInvoiceSummaryResult(
                InvoiceSummary: invoiceSummary));
    }
}
