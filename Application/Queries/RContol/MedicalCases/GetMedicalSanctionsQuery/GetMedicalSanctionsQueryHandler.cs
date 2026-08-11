using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.MedicalCases.GetMedicalSanctionsQuery;

public class GetMedicalSanctionsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetMedicalSanctionsQuery, Result<GetMedicalSanctionsResult>>
{
    public async Task<Result<GetMedicalSanctionsResult>> Handle(
        GetMedicalSanctionsQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalSanctions = await medicalCaseRepository.GetMedicalSanctionsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetMedicalSanctionsResult>.Success(
            new GetMedicalSanctionsResult(
                MedicalSanctions: medicalSanctions));
    }
}
