using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.Workspace.CompletedCases.GetCompletedCaseDetailsQuery;

public class GetCompletedCaseDetailsQueryHandler(
    ICompletedCaseRepository completedCaseRepository) : IRequestHandler<GetCompletedCaseDetailsQuery, Result<GetCompletedCaseDetailsResult>>
{
    public async Task<Result<GetCompletedCaseDetailsResult>> Handle(
        GetCompletedCaseDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var completedCaseDetails = await completedCaseRepository.GetCompletedCaseDetailsAsync(
            completedCaseUid: request.CompletedCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if (completedCaseDetails is null)
        {
            return Result<GetCompletedCaseDetailsResult>.Failure("Подробная информация по законченному случаю не может отсутствовать");
        }

        return Result<GetCompletedCaseDetailsResult>.Success(
            new GetCompletedCaseDetailsResult(
                CompletedCaseDetails: completedCaseDetails));
    }

}