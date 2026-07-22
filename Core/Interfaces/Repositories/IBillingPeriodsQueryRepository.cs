using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories;

public interface IBillingPeriodsQueryRepository
{
    Task<Result<BillingPeriodsQueryResult>> GetFromStoredProcedureAsync(
        TargetDbType targetDbType,
        string orgCode);
}
