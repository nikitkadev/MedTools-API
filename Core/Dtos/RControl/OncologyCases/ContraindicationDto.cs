namespace Core.Dtos.RControl.OncologyCases;

public sealed record ContraindicationDto(
    int ContraindicationUid,
    byte ContraindicationCode,
    string Contraindication,
    DateTime ContraindicationDate);
