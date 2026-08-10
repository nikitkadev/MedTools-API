using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.KsgVmp;

namespace Core.Interfaces.Repositories.Categories;

public interface IKsgVmpCategoryRepository
{
    

    Task<Result<KsgVmpTablesQueryResult>> GetTablesDataAsync(
        int ksgKpgUid,
        TargetDbType targetDb);
}
