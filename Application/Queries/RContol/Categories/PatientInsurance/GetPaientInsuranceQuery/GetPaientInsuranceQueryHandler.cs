using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Categories;

namespace Application.Queries.RContol.Categories.PatientInsurance.GetPaientInsuranceQuery;

public class GetPaientInsuranceQueryHandler(
    IPatientInsuranceRepository patientInsuranceRepository) : IRequestHandler<GetPaientInsuranceQuery, Result<GetPaientInsuranceResult>>
{
    public async Task<Result<GetPaientInsuranceResult>> Handle(
        GetPaientInsuranceQuery request, 
        CancellationToken cancellationToken)
    {
        var patient = patientInsuranceRepository.GetPatient(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb);

        var insurance = patientInsuranceRepository.GetInsurance(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb);

        return Result<GetPaientInsuranceResult>.Success(
            new GetPaientInsuranceResult(
                Patient: patient,
                Insurance: insurance));
    }

}