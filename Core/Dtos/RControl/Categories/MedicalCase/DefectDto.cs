namespace Core.Dtos.RControl.Categories.MedicalCase;

public sealed record DefectDto(
    int DefectUid,
    short? Code,
    string Comment);
