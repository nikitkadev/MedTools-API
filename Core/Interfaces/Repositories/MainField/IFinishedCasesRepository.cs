using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories.MainField;

public interface IFinishedCasesRepository
{
    Task<Result<FinishedCasesQueryResult>> GetFromStoredProcedureAsync(
        int schetUid,
        TargetDbType dbType,
        int page,
        int pageSize,
        string searchString);
}
