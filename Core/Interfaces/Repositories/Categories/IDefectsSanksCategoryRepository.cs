using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.DefectsSanks;

namespace Core.Interfaces.Repositories.Categories;

public interface IDefectsSanksCategoryRepository
{
    Task<Result<SanksQueryResult>> GetSanksAsync(
        int sluchUid,
        TargetDbType targetDb);

    Task<Result<DefectsQueryResult>> GetDefectsAsync(
        int sluchUid,
        TargetDbType targetDb,
        int page,
        int pageSize);
}
