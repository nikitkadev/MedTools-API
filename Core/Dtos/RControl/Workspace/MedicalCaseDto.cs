namespace Core.Dtos.RControl.Workspace;

public sealed record MedicalCaseDto(
    int MedicalCaseUid,
    int? MedicalProfile,
    short IsPediatric,
    int PhysicianSpecialty,
    DateTime TreatmentStartDate,
    DateTime TreatmentEndDate,
    string PrimaryDiagnosis,
    decimal? PaidUnits,
    decimal? UnitRate,
    decimal AmountBilled,
    decimal? ApprovedAmount,
    decimal? InsuranceCompanyApprovedAmount);
