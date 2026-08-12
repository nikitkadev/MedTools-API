namespace Core.Dtos.RControl.Medications;

public sealed record InjectionDateDto(
    int InjectionDateUid,
    DateTime AdministrationDate);
