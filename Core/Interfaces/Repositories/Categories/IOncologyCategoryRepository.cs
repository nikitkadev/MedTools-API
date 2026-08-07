using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.Oncology;

namespace Core.Interfaces.Repositories.Categories;

public interface IOncologyCategoryRepository
{

    Task<Result<InjectionsQueryResult>> GetInjectionDataFromStoredProcedureAsync(
        int medicamentUid,
        TargetDbType targetDb);
}
