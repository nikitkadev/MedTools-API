using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiseaseOutcomeFilterOptionsQuery;

public sealed record GetDiseaseOutcomeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
