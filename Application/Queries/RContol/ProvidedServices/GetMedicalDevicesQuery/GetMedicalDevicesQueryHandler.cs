using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories;

namespace Application.Queries.RContol.ProvidedServices.GetMedicalDevicesQuery;

public class GetMedicalDevicesQueryHandler(
    IProvidedServiceRepository providedServiceRepository) : IRequestHandler<GetMedicalDevicesQuery, Result<GetMedicalDevicesResult>>
{
    public async Task<Result<GetMedicalDevicesResult>> Handle(
        GetMedicalDevicesQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalDevices = await providedServiceRepository.GetMedicalDevicesAsync(
            providedServiceUid: request.ProvidedServiceUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetMedicalDevicesResult>.Success(
            new GetMedicalDevicesResult(
                MedicalDevices: medicalDevices));
    }
}
