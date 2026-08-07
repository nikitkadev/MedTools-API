namespace Core.Dtos.RControl.Workspace;

public sealed record ConsultationDto(
    int ConsultationUid,
    byte ConsultationPurposeCode,
    string ConsultationPurpose,
    DateTime? ConsultationDate);
