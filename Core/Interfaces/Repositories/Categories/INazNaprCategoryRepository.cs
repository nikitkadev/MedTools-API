using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.NazNapr;

namespace Core.Interfaces.Repositories.Categories;

public interface INazNaprCategoryRepository
{
    Task<Result<NazNaprQueryResult>> GetDataAsync(
        int sluchUid,
        TargetDbType targetDb);
}
