using Core.Enums;
using Core.Dtos.Lookups;

namespace Core.Interfaces.Repositories.Lookups;

public interface IMedicalOrganizationRepository
{
    Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
