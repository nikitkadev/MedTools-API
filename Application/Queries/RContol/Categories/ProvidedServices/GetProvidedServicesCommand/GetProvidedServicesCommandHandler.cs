using MediatR;

using Core.Common;
using Core.Dtos.Categories.ProvidedServices;
using Core.Interfaces.Repositories.Categories;

namespace Application.Queries.RContol.Categories.ProvidedServices.GetProvidedServicesCommand;

public class GetProvidedServicesCommandHandler(
    IProvidedServicesCategoryRepository providedServicesCategoryRepository) : IRequestHandler<GetProvidedServicesCommand, Result<ProvidedServicesQueryResult>>
{
    public async Task<Result<ProvidedServicesQueryResult>> Handle(
        GetProvidedServicesCommand request, 
        CancellationToken cancellationToken)
    {
        return await providedServicesCategoryRepository.GetProvidedServicesFromStoredProcedureAsync(
            sluchUid: request.SluchUid,
            targetDb: request.TargetDb);
    }
}
