using Core.Common.Enums;
using Core.Dtos.RControl.OncologyCases;

namespace Core.Interfaces.Repositories.RControl;

public interface IOncologyCaseRepository
{
    Task<IReadOnlyCollection<ContraindicationDto>> GetContraindicationsAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<DiagnosticsListItemDto>> GetDiagnosticsAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<OncologyServiceDto>> GetOncologyServicesAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
