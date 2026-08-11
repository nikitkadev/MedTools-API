using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.MedicalCases.GetConsultationsQuery;

public class GetConsultationsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetConsultationsQuery, Result<GetConsultationsResult>>
{
    public async Task<Result<GetConsultationsResult>> Handle(
        GetConsultationsQuery request, 
        CancellationToken cancellationToken)
    {
        var consulations = await medicalCaseRepository.GetConsultationsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetConsultationsResult>.Success(
            new GetConsultationsResult(
                Consultations: consulations));
    }
}
