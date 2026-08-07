namespace Core.Dtos.RControl.Oncology;

public sealed record OncologyServiceDto(
    int OncologyServiceUid,
    byte ServiceTypeCode,
    string ServiceType,
    byte? SurgicalTreatmentTypeCode,
    string? SurgicalTreatmentType,
    byte? DrugTherapyLineCode,
    string? DrugTherapyLine,
    byte? DrugTherapyCycleCode,
    string? DrugTherapyCycle,
    bool? IsAntiemeticProphylaxis,
    byte? RadioTherapyTypeCode,
    string? RadiotherapyType);
