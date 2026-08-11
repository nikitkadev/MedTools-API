using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RContol.MedicalCases.GetProvidedServicesQuery;

public sealed record GetProvidedServicesResult(IReadOnlyCollection<ProvidedServiceListItemDto> ProvidedServices);
