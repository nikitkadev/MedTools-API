using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Categories.ProvidedServices;

namespace Core.Interfaces.Repositories.Categories;

public interface IProvidedServicesCategoryRepository
{
    Task<Result<MedDevsQueryResult>> GetMedDevsFromStoredProcedureAsync(
        int providedServiceUid,
        TargetDbType targetDb);
}
