using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.Oncology;

namespace Core.Interfaces.Repositories.Categories;

public interface IOncologyCategoryRepository
{

    Task<Result<DetailedOncSluchQueryResult>> GetDetailedOncSluchFromStoredProcedureAsync(
        int oncSluchUid,
        TargetDbType targetDb);

    Task<Result<MedicamentsQueryResult>> GetMedicamentsFromStoredProcedureAsync(
        int oncServiceUid,
        TargetDbType targetDb);

    Task<Result<InjectionsQueryResult>> GetInjectionDataFromStoredProcedureAsync(
        int medicamentUid,
        TargetDbType targetDb);
}
