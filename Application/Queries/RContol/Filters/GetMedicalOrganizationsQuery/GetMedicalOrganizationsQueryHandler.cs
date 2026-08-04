using MediatR;

using Core.Common;
using Core.Interfaces.Repositories.Filters;

namespace Application.Queries.RContol.Filters.GetMedicalOrganizationsQuery;

public class GetMedicalOrganizationsQueryHandler(
    IMedicalOrganizationRepository medOrganizationsQueryRepository) : IRequestHandler<GetMedicalOrganizationsQuery, Result<GetMedicalOrganizationsResult>>
{
    public async Task<Result<GetMedicalOrganizationsResult>> Handle(
        GetMedicalOrganizationsQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalOrganizations = await medOrganizationsQueryRepository.GetMedicalOrgnizationsAsyn(request.TargetDb, cancellationToken);

        return Result<GetMedicalOrganizationsResult>.Success(
            new GetMedicalOrganizationsResult(
                MedicalOrganizations: medicalOrganizations));
    }
}
