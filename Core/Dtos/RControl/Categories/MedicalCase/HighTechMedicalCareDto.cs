namespace Core.Dtos.RControl.Categories.MedicalCase;

public sealed record HighTechMedicalCareDto(
    string? HighTechCareTypeCode,
    string? HighTechCareMethodCode,
    DateTime? VoucherIssueDate,
    string? VoucherNumber,
    DateTime? PlannedAdmissionDate);
