namespace Core.Dtos.RControl.MedicalCases;

public sealed record MedicalSanctionDto(
    int MedicalSanctionUid,
    string SanctionCode,
    decimal SanctionAmount,
    string ControlTypeCode,
    int RefusalReasonCode,
    string? Comment,
    short Source,
    decimal UnitsRemoved,
    DateTime ExpertiseActDate,
    string ExpertiseActNumber,
    string? ExpertCode,
    string Filename,
    int? Year,
    int? Month,
    DateTime? UploadDate);