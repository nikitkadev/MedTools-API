using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories.Categories;

public interface ICasesCategoryRepository
{
    Task<Result<CategoryCasesQueryResult>> GetFromStoredProcedureAsync(
       int sluchUid,
       TargetDbType targetDb);
}
