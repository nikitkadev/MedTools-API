namespace Core.Dtos.RControl.Categories.Oncology;

public sealed record OncologyCaseDto(
    int OncologyCaseUid,
    byte? ReferralReasonCode,
    string? ReferralReason,
    int? Stage,
    int? TumorValue,
    int? NodusValue,
    int? MetastasisValue,
    bool? IsMetastasisDetected,
    float? TotalFocusDose,
    byte? RadiationFractionsCount,
    float? Weight,
    int? Height,
    float? BodySurfaceArea);
