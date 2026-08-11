namespace Core.Dtos.RControl.Categories.MedicalCase;

public sealed record PrescriptionDto(
    int PerscriptionUid,
    int SequenceNumber,
    byte PrescriptionTypeCode,
    string PrescriptionType,
    string? PhysicianSpecialtyCode,
    byte? DiagnosticMethodCode,
    string? DiagnosticMethod,
    string? ServiceCode,
    DateTime? ReferralDate,
    string? ReferredToMoCode,
    int? MedicalCareProfile,
    string? BedProfile);
