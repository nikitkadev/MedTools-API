namespace Core.Dtos.RControl.OncologyCases;

public sealed record DiagnosticsListItemDto(
    int DiagnosticsUid,
    DateTime? SpecimenCollectionDate,
    byte? DiagnosticType,
    int? DiagnosticCode,
    int? DiagnosticResultCode,
    bool? IsResultReceived);
