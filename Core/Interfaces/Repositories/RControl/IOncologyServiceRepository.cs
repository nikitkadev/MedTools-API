using Core.Common.Enums;
using Core.Dtos.RControl.OncologyServices;

namespace Core.Interfaces.Repositories.RControl;

public interface IOncologyServiceRepository
{
    Task<IReadOnlyCollection<MedicationDto>> GetMedicationsAsync(
        int oncologyServiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}
