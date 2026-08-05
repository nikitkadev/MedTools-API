using Core.Dtos.Lookups;

namespace Application.Queries.RContol.Lookups.GetBillingPeriodsQuery;

public record GetBillingPeriodsResult(IReadOnlyCollection<BillingPeriodDto> BillingPeriods);
