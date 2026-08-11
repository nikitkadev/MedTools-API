using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.MedicalCases.GetProvidedServicesQuery;

public class GetProvidedServicesQueryHandler(
    IMedicalCaseRepository medicalCaseRepository) : IRequestHandler<GetProvidedServicesQuery, Result<GetProvidedServicesResult>>
{
    public async Task<Result<GetProvidedServicesResult>> Handle(
        GetProvidedServicesQuery request, 
        CancellationToken cancellationToken)
    {
        var providedServices = await medicalCaseRepository.GetProvidedServicesAsync(
            medicalCaseUid: request.MedicalCaseUid,
            targetDb: request.TargetDb,
            cancellationToken: cancellationToken);

        return Result<GetProvidedServicesResult>.Success(
            new GetProvidedServicesResult(
                ProvidedServices: providedServices));
    }
}