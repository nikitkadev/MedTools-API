using Core.Common;
using Core.Dtos;
using Core.Enums;

namespace Core.Interfaces.Repositories.MainField;

public interface ICasesRepository
{
    Task<Result<CasesQueryResult>> GetFromStorageProcedureAsync(
        int zSlUid,
        TargetDbType targetDb);
}
