namespace Core.Dtos.RControl.MedicalCases;

public sealed record DefectDto(
    int DefectUid,
    short? Code,
    string Comment);
