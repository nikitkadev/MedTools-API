using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.MedView;

namespace Application.Queries.MedView.CompletedCases.GetCompletedCasesQuery;

public sealed class GetCompletedCasesQueryHandler(
    IMedViewCompletedCasesRepository medViewCompletedCasesRepository) : IRequestHandler<GetCompletedCasesQuery, Result<GetCompletedCasesResult>>
{
    public async Task<Result<GetCompletedCasesResult>> Handle(
        GetCompletedCasesQuery request,
        CancellationToken cancellationToken)
    {
        var completedCasesPaginationResult = await medViewCompletedCasesRepository.GetCompletedCaseListItemsAsync(
            targetDb: request.TargetDb,
            filters: request.Filters,
            cancellationToken: cancellationToken);

        return Result<GetCompletedCasesResult>.Success(
            new GetCompletedCasesResult(
                CompletedCaseListItems: completedCasesPaginationResult.Records,
                TotalCount: completedCasesPaginationResult.TotalCount));
    }
}
