using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCasesQuery;

public sealed class GetCompletedCasesQueryHandler(
    ICompletedCaseRepository completedCaseRepository) : IRequestHandler<GetCompletedCasesQuery, Result<GetCompletedCasesResult>>
{
    public async Task<Result<GetCompletedCasesResult>> Handle(
        GetCompletedCasesQuery request, 
        CancellationToken cancellationToken)
    {
        var completedCasesPaginationResult = await completedCaseRepository.GetCompletedCaseListItemsAsync(
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
