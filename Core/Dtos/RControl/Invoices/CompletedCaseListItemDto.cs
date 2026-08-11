namespace Core.Dtos.RControl.Invoices;

public sealed record CompletedCaseListItemDto(
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
