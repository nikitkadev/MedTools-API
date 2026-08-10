using Core.Dtos.RControl.Categories.Oncology;

namespace Application.Queries.RContol.Oncology.GetInjectionDatesQuery;

public sealed record GetInjectionDatesResult(IReadOnlyCollection<InjectionDateDto> InjectionDates);
