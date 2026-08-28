namespace Application.Queries.RControl.Lookups.GetBillingPeriodsQuery;

public sealed record GetBillingPeriodsResult(IReadOnlyCollection<BillingPeriodResponseDto> BillingPeriods);

public sealed record BillingPeriodResponseDto(
    int BillingYear,
    IReadOnlyCollection<int> BillingMonths);
