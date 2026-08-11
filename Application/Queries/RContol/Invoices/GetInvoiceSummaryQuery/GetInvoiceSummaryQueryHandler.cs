using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.Invoices.GetInvoiceSummaryQuery;

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
