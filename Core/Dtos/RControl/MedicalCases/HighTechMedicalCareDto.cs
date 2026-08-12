namespace Core.Dtos.RControl.MedicalCases;

public sealed record HighTechMedicalCareDto(
    string? HighTechCareTypeCode,
    string? HighTechCareMethodCode,
    DateTime? VoucherIssueDate,
    string? VoucherNumber,
    DateTime? PlannedAdmissionDate);
