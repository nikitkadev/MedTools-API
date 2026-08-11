using Core.Dtos.RControl.Medications;

namespace Application.Queries.RContol.Medications.GetInjectionDatesQuery;

public sealed record GetInjectionDatesResult(IReadOnlyCollection<InjectionDateDto> InjectionDates);
