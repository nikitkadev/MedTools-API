using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.CompletedCases.GetCompletedCaseDetailsQuery;

public sealed class GetCompletedCaseDetailsQueryHandler(
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