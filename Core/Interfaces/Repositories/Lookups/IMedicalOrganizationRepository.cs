using Core.Enums;
using Core.Dtos.RControl.Lookups;

namespace Core.Interfaces.Repositories.Lookups;

public interface IMedicalOrganizationRepository
{
    Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
