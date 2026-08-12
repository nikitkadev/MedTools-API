using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RControl.MedicalCases.GetClinicalGroupQuery;

public sealed class GetClinicalGroupQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetClinicalGroupQuery, Result<GetClinicalGroupResult>>
{
    public async Task<Result<GetClinicalGroupResult>> Handle(
        GetClinicalGroupQuery request, 
        CancellationToken cancellationToken)
    {
        var clinicalGroup = await medicalCaseRepository.GetClinicalGroupAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        if(clinicalGroup is null)
        {
            return Result<GetClinicalGroupResult>.Failure("Не удалось найти данных о клинической группе");
        }

        return Result<GetClinicalGroupResult>.Success(
            new GetClinicalGroupResult(
                ClinicalGroup: clinicalGroup));
    }
}
