namespace Core.Dtos.RControl.Categories.Oncology;

public sealed record InjectionDto(
    int InjectionUid,
    DateTime AdministrationDate,
    decimal? AdministeredQuantity,
    decimal? ConsumedQuantity,
    decimal? UnitCost,
    decimal? AdministeredCost,
    decimal? ConsumedCost,
    bool? IsReductionApplied);
