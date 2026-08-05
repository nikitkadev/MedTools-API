using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.MedicalCases;

namespace Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCasesQuery;

public class GetMedicalCasesQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetMedicalCasesQuery, Result<GetMedicalCasesResult>>
{
    public async Task<Result<GetMedicalCasesResult>> Handle(
        GetMedicalCasesQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalCases = await medicalCaseRepository.GetMedicalCasesAsync(
            completedCaseUid: request.CompletedCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetMedicalCasesResult>.Success(
            new GetMedicalCasesResult(
                MedicalCases: medicalCases));
    }
}
