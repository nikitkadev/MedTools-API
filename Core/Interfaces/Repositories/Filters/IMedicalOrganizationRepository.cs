using Core.Enums;
using Core.Dtos.Filters;

namespace Core.Interfaces.Repositories.Filters;

public interface IMedicalOrganizationRepository
{
    Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrgnizationsAsyn(
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
