using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories;

namespace Application.Queries.RContol.ProvidedServices.GetProvidedServicesQuery;

public class GetProvidedServicesQueryHandler(
    IProvidedServiceRepository providedServiceRepository) : IRequestHandler<GetProvidedServicesQuery, Result<GetProvidedServicesResult>>
{
    public async Task<Result<GetProvidedServicesResult>> Handle(
        GetProvidedServicesQuery request, 
        CancellationToken cancellationToken)
    {
        var providedServices = await providedServiceRepository.GetProvidedServicesAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetProvidedServicesResult>.Success(
            new GetProvidedServicesResult(
                ProvidedServices: providedServices));
    }
}