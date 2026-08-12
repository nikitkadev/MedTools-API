namespace Application.Queries.RControl.Lookups.GetBillingPeriodsQuery;

public sealed record GetBillingPeriodsResult(IReadOnlyCollection<BillingPeriodResponseDto> BillingPeriods);

public sealed record BillingPeriodResponseDto(
    string BillingYear,
    IReadOnlyCollection<string> BillingMonth);
