using Core.Dtos.RControl.Categories.PatientInsurance;

namespace Application.Queries.RContol.Categories.PatientInsurance.GetPatientInsuranceQuery;

public sealed record GetPatientInsuranceResult(
    PatientDto? Patient,
    InsuranceDto? Insurance);
