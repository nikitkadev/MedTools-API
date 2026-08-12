using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.MedicalCases.GetPatientQuery;

public sealed class GetPatientQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetPatientQuery, Result<GetPatientResult>>
{
    public async Task<Result<GetPatientResult>> Handle(
        GetPatientQuery request,
        CancellationToken cancellationToken)
    {
        var patient = await medicalCaseRepository.GetPatientAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if (patient is null)
        {
            return Result<GetPatientResult>.Failure("Не удалось найти данные по пациенту");
        }

        return Result<GetPatientResult>.Success(
            new GetPatientResult(
                Patient: patient));
    }
}
