namespace Core.Dtos.Filters;

public sealed record BillingPeriodDto(
    int BillingYear,
    byte BillingMonth);
