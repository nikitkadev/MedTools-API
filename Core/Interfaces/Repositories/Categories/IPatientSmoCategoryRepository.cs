using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories.Categories;

public interface IPatientSmoCategoryRepository
{
    Task<Result<PatientSmoQueryResult>> GetFromStoredProcedureAsync(
        int sluchUid,
        TargetDbType targetDb);
}
