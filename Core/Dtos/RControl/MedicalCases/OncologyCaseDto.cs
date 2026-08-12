namespace Core.Dtos.RControl.MedicalCases;

public sealed record OncologyCaseDto(
    int OncologyCaseUid,
    byte? ReferralReasonCode,
    string? ReferralReason,
    int? StageCode,
    string? Stage,
    string? IcdDiagnosis,
    int? TumorValue,
    int? NodusValue,
    int? MetastasisValue,
    bool? IsMetastasisDetected,
    float? TotalFocusDose,
    byte? RadiationFractionsCount,
    float? Weight,
    int? Height,
    float? BodySurfaceArea);
