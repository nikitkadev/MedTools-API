namespace Core.Dtos.RControl.MedicalCases;

public sealed record ProvidedServiceListItemDto(
    int ProvidedServiceUid,
    string ServiceCode,
    string Service,
    string? MedicalInterventionType,
    int MedicalProfileCode,
    string MedicalProfile,
    int PhysicianSpecialtyCode,
    string PhysicianSpecialty,
    bool IsPediatric,
    DateTime ServiceStartDate,
    DateTime ServiceEndDate,
    string Diagnosis,
    decimal ServiceQuantity,
    decimal? UnitRate,
    decimal AmountBilled,
    string? InternalComment);
