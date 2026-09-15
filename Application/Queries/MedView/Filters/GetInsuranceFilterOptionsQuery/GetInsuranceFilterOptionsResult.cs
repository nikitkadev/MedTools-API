using Core.Dtos.MedView.Filters;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed record GetInsuranceFilterOptionsResult(IReadOnlyCollection<InsuranceFilterOptionsDto> Options);
