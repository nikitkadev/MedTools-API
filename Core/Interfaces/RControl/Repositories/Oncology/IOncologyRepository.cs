using Core.Enums;
using Core.Dtos.RControl.Oncology;
using Core.Dtos.RControl.Categories.Oncology;

namespace Core.Interfaces.RControl.Repositories.Oncology;

public interface IOncologyRepository
{
    Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<ContraindicationDto>> GetContraindicationsAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<DiagnosticsListItemDto>> GetDiagnosticsAsync(
        int oncologyCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

}