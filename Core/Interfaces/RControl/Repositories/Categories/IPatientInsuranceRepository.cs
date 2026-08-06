using Core.Enums;
using Core.Dtos.RControl.Categories.PatientInsurance;

namespace Core.Interfaces.RControl.Repositories.Categories;

public interface IPatientInsuranceRepository
{
    PatientDto? GetPatient(
        int medicalCaseUid,
        TargetDbType targetDb);

    InsuranceDto? GetInsurance(
        int medicalCaseUid,
        TargetDbType targetDb);

}
