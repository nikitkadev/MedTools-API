using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Categories;

namespace Application.Queries.RContol.Categories.PatientInsurance.GetPatientInsuranceQuery;

public class GetPatientInsuranceQueryHandler(
    IPatientInsuranceRepository patientInsuranceRepository) : IRequestHandler<GetPatientInsuranceQuery, Result<GetPatientInsuranceResult>>
{
    public async Task<Result<GetPatientInsuranceResult>> Handle(
        GetPatientInsuranceQuery request, 
        CancellationToken cancellationToken)
    {
        var patient = patientInsuranceRepository.GetPatient(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb);

        var insurance = patientInsuranceRepository.GetInsurance(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb);

        return Result<GetPatientInsuranceResult>.Success(
            new GetPatientInsuranceResult(
                Patient: patient,
                Insurance: insurance));
    }

}