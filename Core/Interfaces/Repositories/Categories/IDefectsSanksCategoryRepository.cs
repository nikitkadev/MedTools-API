using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.DefectsSanks;

namespace Core.Interfaces.Repositories.Categories;

public interface IDefectsSanksCategoryRepository
{
    Task<Result<SanksQueryResult>> GetSanksAsync(
        int sluchUid,
        TargetDbType targetDb);
}
