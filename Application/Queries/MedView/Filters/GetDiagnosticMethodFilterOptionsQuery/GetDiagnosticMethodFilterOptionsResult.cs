using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetDiagnosticMethodFilterOptionsQuery;

public sealed record GetDiagnosticMethodFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
