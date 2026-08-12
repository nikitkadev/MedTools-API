using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RControl.MedicalCases.GetProvidedServicesQuery;

public sealed record GetProvidedServicesResult(IReadOnlyCollection<ProvidedServiceListItemDto> ProvidedServices);
