namespace Core.Dtos.RControl.Oncology;

public sealed record MedicationDto(
    int MedicamentUid,
    string DrugIdentifier,
    string? DrugExtendedIdentifier,
    string? TherapyRegimenCode);
