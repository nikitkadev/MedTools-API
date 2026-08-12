namespace Core.Dtos.RControl.CompletedCases;

public sealed record CompletedCaseDetailsDto(
    string MedicalOrganizationCode,
    string? ReferringMedicalOrganizationCode,
    DateTime? ReferralDate,
    int CareConditions,
    int MedicalCareType,
    short PaymentMethodCode,
    byte MedicalCareForm,
    DateTime TreatmentStartDate,
    DateTime TreatmentEndDate,
    int? HospitalizationDuration,
    int HospitalizationOutcome,
    bool? IsIntrahospitalTransfer,
    int? ScreeningResult,
    bool? IsRefusal,
    bool? IsMobileTeam,
    int DiseaseOutcome);
