using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.Onkology;

namespace Core.Interfaces.Repositories.Categories;

public interface IOnkologyCategoryRepository
{
    Task<Result<OnkSluchQueryResult>> GetOnkologyCaseFromStoredProcedureAsync(
        int sluchUid,
        TargetDbType targetDb);
}
