namespace Core.Dtos.RControl.OncologyServices;

public sealed record MedicationDto(
    int MedicamentUid,
    string DrugIdentifier,
    string? DrugExtendedIdentifier,
    string? TherapyRegimenCode);
