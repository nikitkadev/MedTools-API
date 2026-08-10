using Core.Dtos.RControl.ProvidedServices;

namespace Application.Queries.RContol.ProvidedServices.GetProvidedServicesQuery;

public sealed record GetProvidedServicesResult(IReadOnlyCollection<ProvidedServiceListItemDto> ProvidedServices);
