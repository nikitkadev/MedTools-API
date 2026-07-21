using Core.Common;
using Core.Dtos;
using Core.Enums;

namespace Core.Interfaces.Repositories;

public interface IMedOrganizationsQueryRepository
{
    Task<Result<MedOrganizationsQueryResult>> GetFromStoredProcedureAsync(TargetDbType dbType);
}
