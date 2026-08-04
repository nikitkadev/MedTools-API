using Core.Dtos.Filters;

namespace Application.Queries.RContol.Filters.GetBillingPeriodsQuery;

public record GetBillingPeriodsResult(IReadOnlyCollection<BillingPeriodDto> BillingPeriods);
