using MediatR;
using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.MedicalCases.GetPrescriptionsQuery;

public class GetPrescriptionsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetPrescriptionsQuery, Result<GetPrescriptionsResult>>
{
    public async Task<Result<GetPrescriptionsResult>> Handle(
        GetPrescriptionsQuery request, 
        CancellationToken cancellationToken)
    {
        var prescriptions = await medicalCaseRepository.GetPrescriptionsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetPrescriptionsResult>.Success(
            new GetPrescriptionsResult(
                Prescriptions: prescriptions));
    }
}
