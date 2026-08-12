using Core.Dtos.RControl.Medications;

namespace Application.Queries.RControl.Medications.GetInjectionDatesQuery;

public sealed record GetInjectionDatesResult(IReadOnlyCollection<InjectionDateDto> InjectionDates);
