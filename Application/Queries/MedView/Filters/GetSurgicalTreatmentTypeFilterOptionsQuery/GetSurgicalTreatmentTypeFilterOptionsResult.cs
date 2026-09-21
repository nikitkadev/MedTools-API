using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetSurgicalTreatmentTypeFilterOptionsQuery;

public sealed record GetSurgicalTreatmentTypeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
