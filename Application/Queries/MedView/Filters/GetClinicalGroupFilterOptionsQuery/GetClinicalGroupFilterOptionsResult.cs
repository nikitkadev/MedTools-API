using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetClinicalGroupFilterOptionsQuery;

public sealed record GetClinicalGroupFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
