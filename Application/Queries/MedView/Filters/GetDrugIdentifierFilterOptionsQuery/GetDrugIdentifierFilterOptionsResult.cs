using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDrugIdentifierFilterOptionsQuery;

public sealed record GetDrugIdentifierFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
