using MediatR;

using Core.Common.Results;
using Core.Interfaces.Repositories.RControl;

namespace Application.Queries.RContol.Lookups.GetMedicalOrganizationsQuery;

public sealed class GetMedicalOrganizationsQueryHandler(
    ILookupsRepository lookupsRepository) : IRequestHandler<GetMedicalOrganizationsQuery, Result<GetMedicalOrganizationsResult>>
{
    public async Task<Result<GetMedicalOrganizationsResult>> Handle(
        GetMedicalOrganizationsQuery request, 
        CancellationToken cancellationToken)
    {
        var medicalOrganizations = await lookupsRepository.GetMedicalOrganizationsAsync(request.TargetDb, cancellationToken);

        return Result<GetMedicalOrganizationsResult>.Success(
            new GetMedicalOrganizationsResult(
                MedicalOrganizations: medicalOrganizations));
    }
}
