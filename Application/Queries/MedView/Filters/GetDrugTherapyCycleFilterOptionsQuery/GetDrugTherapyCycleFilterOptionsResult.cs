using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDrugTherapyCycleFilterOptionsQuery;

public sealed record GetDrugTherapyCycleFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
