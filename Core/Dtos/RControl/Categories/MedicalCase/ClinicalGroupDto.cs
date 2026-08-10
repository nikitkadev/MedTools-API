namespace Core.Dtos.RControl.Categories.MedicalCase;

public sealed record ClinicalGroupDto(
    int ClinicalGroupUid,
    string ClinicalStatisticGroupNumber,
    string? CalculatedClinicalStatisticGroupNumber,
    int ClinicalStatisticGroupModelVersion,
    bool IsCsgSubgroupUsed,
    string? ClinicalProfileGroupNumber,
    float CostCoefficient,
    float ManagementCoefficient,
    decimal BaseRate,
    float DifferentiationCoefficient,
    float LevelCoefficient,
    float? WageTargetCoefficient,
    bool IsClspUsed,
    float? ComplexityCoefficient);
