using Core.Dtos.RControl.Oncology;

namespace Application.Queries.RContol.Oncology.GetDignosticsQuery;

public sealed record GetDignosticsResult(IReadOnlyCollection<DiagnosticsListItemDto> Diagnostics);
