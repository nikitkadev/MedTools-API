using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.MedicalCases.GetHighTechMedicalCareQuery;

public sealed class GetHighTechMedicalCareQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetHighTechMedicalCareQuery, Result<GetHighTechMedicalCareResult>>
{
    public async Task<Result<GetHighTechMedicalCareResult>> Handle(
        GetHighTechMedicalCareQuery request,
        CancellationToken cancellationToken)
    {
        var highTechMedicalCare = await medicalCaseRepository.GetHighTechMedicalCareAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if (highTechMedicalCare is null)
        {
            return Result<GetHighTechMedicalCareResult>.Failure("Не удалось найти данных о ВМП");
        }

        return Result<GetHighTechMedicalCareResult>.Success(
            new GetHighTechMedicalCareResult(
                HighTechMedicalCare: highTechMedicalCare));
    }
}
