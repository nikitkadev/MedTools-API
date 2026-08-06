using Core.Dtos.RControl.Categories.PatientInsurance;

namespace Application.Queries.RContol.Categories.PatientInsurance.GetPaientInsuranceQuery;

public sealed record GetPaientInsuranceResult(
    PatientDto? Patient,
    InsuranceDto? Insurance);
