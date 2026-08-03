namespace Core.Dtos;

public record BillingPeriodsQueryResult(
    List<BillingPeriodDto> BillingPeriods);

public record BillingPeriodDto(
    int Year,
    int Month);

