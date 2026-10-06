using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetComplexityCoefficientOptionsQuery;

public sealed record GetComplexityCoefficientOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
