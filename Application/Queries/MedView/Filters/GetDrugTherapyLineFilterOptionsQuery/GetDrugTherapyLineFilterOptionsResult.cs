using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDrugTherapyLineFilterOptionsQuery;

public sealed record GetDrugTherapyLineFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
