using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Workspace;

namespace Application.Queries.RContol.Workspace.MedicalCases.GetMedicalCaseDetailsQuery;

public class GetMedicalCaseDetailsQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetMedicalCaseDetailsQuery, Result<GetMedicalCaseDetailsResult>>
{
    public async Task<Result<GetMedicalCaseDetailsResult>> Handle(
        GetMedicalCaseDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalCaseDetails = await medicalCaseRepository.GetMedicalCaseDetailsAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if(medicalCaseDetails is null)
        {
            return Result<GetMedicalCaseDetailsResult>.Failure("Подробная информация по медицинскому случаю не может отсутствовать");
        }

        return Result<GetMedicalCaseDetailsResult>.Success(
            new GetMedicalCaseDetailsResult(
                MedicalCaseDetails: medicalCaseDetails));
    }
}
