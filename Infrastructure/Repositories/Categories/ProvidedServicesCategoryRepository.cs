using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;
using Core.Dtos.RControl.Categories.ProvidedServices;

namespace Infrastructure.Repositories.Categories;

public class ProvidedServicesCategoryRepository(
    DbContextFactory dbContextFactory) : IProvidedServicesCategoryRepository
{
    public async Task<Result<ProvidedServicesQueryResult>> GetProvidedServicesFromStoredProcedureAsync(
        int sluchUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expression = "EXEC sp26_provided_services_category_get_provided_services @sluchUid";

        var records = await dbContext.ProvidedServices.FromSqlRaw(expression, [new SqlParameter("@sluchUid", sluchUid)]).ToListAsync();

        return Result<ProvidedServicesQueryResult>.Success(
            new ProvidedServicesQueryResult(
                ProvidedServices: records));
    }

    public async Task<Result<MedDevsQueryResult>> GetMedDevsFromStoredProcedureAsync(
        int providedServiceUid,
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expression = "EXEC sp26_provided_services_category_get_med_devs @uslUid";

        var records = await dbContext.MedDevs.FromSqlRaw(expression, [new SqlParameter("@uslUid", providedServiceUid)]).ToListAsync();

        return Result<MedDevsQueryResult>.Success(
            new MedDevsQueryResult(
                MedDevs: records));
    }
}