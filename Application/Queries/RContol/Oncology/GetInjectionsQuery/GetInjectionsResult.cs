using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Oncology.GetInjectionsQuery;

public sealed record GetInjectionsResult(IReadOnlyCollection<InjectionDto> Injections);
