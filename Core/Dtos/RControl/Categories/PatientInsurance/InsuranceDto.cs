namespace Core.Dtos.RControl.Categories.PatientInsurance;

public sealed record InsuranceDto(
    string? InsuranceCompanyCode,
    string? InsuranceCompanyName,
    string? OGRN,
    string? OKATO,
    string? InsurancePolicyUnifiedNumber,
    string? InsurancePolicySeries,
    string InsurancePolicyNumber,
    byte InsurancePolicyTypeCode,
    string InsurancePolicyTypeName);
