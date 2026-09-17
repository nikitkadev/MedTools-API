using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetHospitalizationOutcomeFilterOptionsQuery;

public sealed record GetHospitalizationOutcomeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
