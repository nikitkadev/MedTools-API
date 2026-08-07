using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.MedicalCases.GetConsulationsQuery;

public class GetConsulationsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetConsulationsQuery, Result<GetConsulationsResult>>
{
    public async Task<Result<GetConsulationsResult>> Handle(
        GetConsulationsQuery request, 
        CancellationToken cancellationToken)
    {
        var consulations = await medicalCaseRepository.GetConsultationsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetConsulationsResult>.Success(
            new GetConsulationsResult(
                Consultations: consulations));
    }
}
