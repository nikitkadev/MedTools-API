using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.Oncology;

namespace Core.Interfaces.Repositories.Categories;

public interface IOncologyCategoryRepository
{
    Task<Result<OncSluchQueryResult>> GetOnkologyCaseFromStoredProcedureAsync(
        int sluchUid,
        TargetDbType targetDb);

    Task<Result<ConsultationsQueryResult>> GetConsultationFromStoredProcedureAsync(
        int sluchUid,
        TargetDbType targetDb);

    Task<Result<DetailedOncSluchQueryResult>> GetDetailedOncSluchFromStoredProcedureAsync(
        int oncSluchUid,
        TargetDbType targetDb);
}
