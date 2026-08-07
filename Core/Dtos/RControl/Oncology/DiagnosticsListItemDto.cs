namespace Core.Dtos.RControl.Oncology;

public sealed record DiagnosticsListItemDto(
    int DiagnosticsUid,
    DateTime? SpecimenCollectionDate,
    byte? DiagnosticType,
    int? DiagnosticCode,
    int? DiagnosticResultCode,
    bool? IsResultReceived);
