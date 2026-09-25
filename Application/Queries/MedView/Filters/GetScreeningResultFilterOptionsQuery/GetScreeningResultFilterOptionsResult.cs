using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetScreeningResultFilterOptionsQuery;

public sealed record GetScreeningResultFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
