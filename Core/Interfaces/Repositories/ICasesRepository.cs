using Core.Common;
using Core.Dtos;
using Core.Enums;

namespace Core.Interfaces.Repositories;

public interface ICasesRepository
{
    Task<Result<CasesQueryResult>> GetFromStorageProcedureAsync(
        int zSlUid,
        TargetDbType targetDb);
}
