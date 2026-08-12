using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.CompletedCases.GetMedicalCasesQuery;

public sealed class GetMedicalCasesQueryHandler(
    ICompletedCaseRepository completedCaseRepository) : IRequestHandler<GetMedicalCasesQuery, Result<GetMedicalCasesResult>>
{
    public async Task<Result<GetMedicalCasesResult>> Handle(
        GetMedicalCasesQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalCases = await completedCaseRepository.GetMedicalCaseListItemsAsync(
            completedCaseUid: request.CompletedCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetMedicalCasesResult>.Success(
            new GetMedicalCasesResult(
                MedicalCases: medicalCases));
    }
}
