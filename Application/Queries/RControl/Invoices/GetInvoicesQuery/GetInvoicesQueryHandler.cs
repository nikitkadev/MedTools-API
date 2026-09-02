using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.Invoices.GetInvoicesQuery;

public sealed class GetInvoicesQueryHandler(
    IInvoiceRepository invoiceRepository) : IRequestHandler<GetInvoicesQuery, Result<GetInvoicesResult>>
{
    public async Task<Result<GetInvoicesResult>> Handle(
        GetInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var invoices = await invoiceRepository.GetInvoiceListItemsAsync(
            medicalOrganizationCode: request.MedicalOrganizationCode,
            year: request.BillingYear,
            month: request.BillingMonth,
            page: request.Page,
            pageSize: request.PageSize,
            searchString: request.SearchString,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetInvoicesResult>.Success(
            new GetInvoicesResult(
                Invoices: invoices.Records,
                RecordsCount: invoices.TotalCount));
    }
}