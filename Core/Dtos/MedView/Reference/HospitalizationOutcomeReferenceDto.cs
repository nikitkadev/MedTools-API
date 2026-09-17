namespace Core.Dtos.MedView.Reference;

public sealed record HospitalizationOutcomeReferenceDto(
    short Id,
    short CareConditionId,
    string Name);
