using Core.Dtos.RControl.OncologyCases;

namespace Application.Queries.RContol.OncologyCases.GetDignosticsQuery;

public sealed record GetDignosticsResult(IReadOnlyCollection<DiagnosticsListItemDto> Diagnostics);
