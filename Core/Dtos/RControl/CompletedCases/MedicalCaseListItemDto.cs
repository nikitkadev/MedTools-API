namespace Core.Dtos.RControl.CompletedCases;

public sealed record MedicalCaseListItemDto(
    int MedicalCaseUid,
    int? MedicalProfile,
    bool IsPediatric,
    int PhysicianSpecialty,
    DateTime TreatmentStartDate,
    DateTime TreatmentEndDate,
    string PrimaryDiagnosis,
    decimal? PaidUnits,
    decimal? UnitRate,
    decimal AmountBilled,
    decimal? ApprovedAmount,
    decimal? InsuranceCompanyApprovedAmount);
