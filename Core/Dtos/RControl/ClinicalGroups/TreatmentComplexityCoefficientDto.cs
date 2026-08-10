namespace Core.Dtos.RControl.ClinicalGroups;

public sealed record TreatmentComplexityCoefficientDto(
    int TreatmentComplexityCoefficientUid,
    string? ComplexityCoefficientNumber,
    float ComplexityCoefficientValue);
