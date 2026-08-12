namespace Core.Dtos.RControl.MedicalCases;

public sealed record ConsultationDto(
    int ConsultationUid,
    byte ConsultationPurposeCode,
    string ConsultationPurpose,
    DateTime? ConsultationDate);
