using Core.Enums;
using Core.Dtos.RControl.Lookups;

namespace Core.Interfaces.RControl.Repositories.Lookups;

public interface IMedicalOrganizationRepository
{
    Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
