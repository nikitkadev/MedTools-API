using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetPaymentMethodFilterOptionsQuery;

public sealed record GetPaymentMethodFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
