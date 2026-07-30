using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.ProvidedServices;

namespace Core.Interfaces.Repositories.Categories;

public interface IProvidedServicesCategoryRepository
{
    Task<Result<ProvidedServicesQueryResult>> GetProvidedServicesFromStoredProcedureAsync(
        int sluchUid,
        TargetDbType targetDb);

    Task<Result<MedDevsQueryResult>> GetMedDevsFromStoredProcedureAsync(
        int providedServiceUid,
        TargetDbType targetDb);
}
