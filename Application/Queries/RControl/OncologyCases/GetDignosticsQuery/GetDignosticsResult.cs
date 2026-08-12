using Core.Dtos.RControl.OncologyCases;

namespace Application.Queries.RControl.OncologyCases.GetDignosticsQuery;

public sealed record GetDignosticsResult(IReadOnlyCollection<DiagnosticsListItemDto> Diagnostics);
