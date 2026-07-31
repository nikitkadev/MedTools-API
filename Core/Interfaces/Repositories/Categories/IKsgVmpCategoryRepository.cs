using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.KsgVmp;

namespace Core.Interfaces.Repositories.Categories;

public interface IKsgVmpCategoryRepository
{
    Task<Result<KsgVmpCardsDataQueryResult>> GetCardsDataAsync(
        int sluchUid,
        TargetDbType targetDb);
}
