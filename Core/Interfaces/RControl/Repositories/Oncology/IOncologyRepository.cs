using Core.Enums;
using Core.Dtos.RControl.Categories.Oncology;

namespace Core.Interfaces.RControl.Repositories.Oncology;

public interface IOncologyRepository
{
    Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken); 

}
