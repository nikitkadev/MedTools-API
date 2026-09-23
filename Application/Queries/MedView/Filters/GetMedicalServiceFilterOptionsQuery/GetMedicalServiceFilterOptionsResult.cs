using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetMedicalServiceFilterOptionsQuery;

public sealed record GetMedicalServiceFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
