using Core.Dtos.RControl.Medications;

namespace Application.Queries.RControl.Medications.GetInjectionsQuery;

public sealed record GetInjectionsResult(IReadOnlyCollection<InjectionDto> Injections);
