namespace Core.Dtos.RControl.Oncology;

public sealed record ContraindicationDto(
    int ContraindicationUid,
    byte ContraindicationCode,
    string Contraindication,
    DateTime ContraindicationDate);
