using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.Invoices.GetCompletedCasesQuery;

public sealed class GetCompletedCasesQueryHandler(
    IInvoiceRepository invoiceRepository) : IRequestHandler<GetCompletedCasesQuery, Result<GetCompletedCasesResult>>
{
    public async Task<Result<GetCompletedCasesResult>> Handle(
        GetCompletedCasesQuery request, 
        CancellationToken cancellationToken)
    {
        var completedCasesPaginationResult = await invoiceRepository.GetCompletedCaseListItemsAsync(
            invoiceUid: request.InvoiceUid,
            page: request.Page,
            pageSize: request.PageSize,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetCompletedCasesResult>.Success(
            new GetCompletedCasesResult(
                CompletedCases: completedCasesPaginationResult.Records,
                TotalCount: completedCasesPaginationResult.TotalCount));
    }
}
