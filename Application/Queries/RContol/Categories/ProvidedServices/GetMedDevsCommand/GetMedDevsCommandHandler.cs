using MediatR;

using Core.Common;
using Core.Dtos.Categories.ProvidedServices;
using Core.Interfaces.Repositories.Categories;

namespace Application.Queries.RContol.Categories.ProvidedServices.GetMedDevsCommand;

public class GetMedDevsCommandHandler(
    IProvidedServicesCategoryRepository providedServicesCategoryRepository) : IRequestHandler<GetMedDevsCommand, Result<MedDevsQueryResult>>
{
    public async Task<Result<MedDevsQueryResult>> Handle(
        GetMedDevsCommand request, 
        CancellationToken cancellationToken)
    {
        return await providedServicesCategoryRepository.GetMedDevsFromStoredProcedureAsync(
            providedServiceUid: request.ProvidedServiceUid,
            targetDb: request.TargetDb);
    }
}