using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetControlTypeCodeFilterOptionsQuery;

public sealed record GetControlTypeCodeFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
