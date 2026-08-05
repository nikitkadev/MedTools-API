using Core.Dtos.RControl.Lookups;

namespace Application.Queries.RContol.Lookups.GetBillingPeriodsQuery;

public record GetBillingPeriodsResult(IReadOnlyCollection<BillingPeriodDto> BillingPeriods);
