using Core.Dtos.RControl.Medications;

namespace Application.Queries.RContol.Medications.GetInjectionsQuery;

public sealed record GetInjectionsResult(IReadOnlyCollection<InjectionDto> Injections);
