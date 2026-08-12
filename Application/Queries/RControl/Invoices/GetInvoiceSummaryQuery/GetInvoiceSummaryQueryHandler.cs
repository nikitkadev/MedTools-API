using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.Invoices.GetInvoiceSummaryQuery;

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
            return Result<GetInvoiceSummaryResult>.Failure("Не удалось получить общую информацию о счете"); 
        }

        return Result<GetInvoiceSummaryResult>.Success(
            new GetInvoiceSummaryResult(
                InvoiceSummary: invoiceSummary));
    }
}
