namespace Core.Dtos.RControl.Workspace;

public sealed record CompletedCaseDto(
    int CompletedCaseUid,
    long EntryNumber,
    decimal AmountBilled,
    decimal? ApprovedAmount,
    decimal? InsuranceCompanyApprovedAmount,
    int MedicalCareConditions,
    string PatientLastName,
    string PatientFirstName,
    string PatientMiddleName,
    string? InsurancePolicySeries,
    string InsurancePolicyNumber,
    long EntryPositionNumber);
