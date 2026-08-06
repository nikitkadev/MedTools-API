using MediatR;

using Core.Common;
using Core.Interfaces.RControl.Repositories.Lookups;

namespace Application.Queries.RContol.Lookups.GetMedicalOrganizationsQuery;

public sealed class GetMedicalOrganizationsQueryHandler(
    IMedicalOrganizationRepository medicalOrganizationRepository) : IRequestHandler<GetMedicalOrganizationsQuery, Result<GetMedicalOrganizationsResult>>
{
    public async Task<Result<GetMedicalOrganizationsResult>> Handle(
        GetMedicalOrganizationsQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalOrganizations = await medicalOrganizationRepository.GetMedicalOrganizationsAsync(request.TargetDb, cancellationToken);

        return Result<GetMedicalOrganizationsResult>.Success(
            new GetMedicalOrganizationsResult(
                MedicalOrganizations: medicalOrganizations));
    }
}
