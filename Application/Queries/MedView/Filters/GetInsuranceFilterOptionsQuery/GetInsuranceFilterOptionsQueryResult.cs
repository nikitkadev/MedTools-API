using Core.Dtos.MedView.Filters;

namespace Application.Queries.MedView.Filters.GetInsuranceFilterOptionsQuery;

public sealed record GetInsuranceFilterOptionsQueryResult(IReadOnlyCollection<InsuranceFilterOptionsDto> InsuranceFilterOptions);
