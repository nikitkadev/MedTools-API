using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;
using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Repositories.Categories;

public class OncologyCategoryRepository(DbContextFactory dbContextFactory) : IOncologyCategoryRepository
{
    public async Task<Result<DetailedOncSluchQueryResult>> GetDetailedOncSluchFromStoredProcedureAsync(
        int oncSluchUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expressionForServices = "EXEC sp26_onk_category_get_onk_usls @onkSluchUid";
        string expressionForСontraindications = "EXEC sp26_onk_category_get_contraindications @onkSluchUid";
        string expressionForDiags = "EXEC sp26_onk_category_get_diags @onkSluchUid";

        var services = await dbContext.OncologyServices.FromSqlRaw(expressionForServices, [new SqlParameter("@onkSluchUid", oncSluchUid)]).ToListAsync();
        var contraindications = await dbContext.Сontraindications.FromSqlRaw(expressionForСontraindications, [new SqlParameter("@onkSluchUid", oncSluchUid)]).ToListAsync();
        var diags = await dbContext.Diags.FromSqlRaw(expressionForDiags, [new SqlParameter("@onkSluchUid", oncSluchUid)]).ToListAsync();

        return Result<DetailedOncSluchQueryResult>.Success(
            new DetailedOncSluchQueryResult(
                Services: services,
                Diags: diags,
                Contraindications: contraindications));

    }

    public async Task<Result<MedicamentsQueryResult>> GetMedicamentsFromStoredProcedureAsync(
        int oncServiceUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expression = "EXEC sp26_onk_category_get_medicaments @oncSluchUid";

        var records = await dbContext.Medicaments.FromSqlRaw(expression, [new SqlParameter("@oncSluchUid", oncServiceUid)]).ToListAsync();

        return Result<MedicamentsQueryResult>.Success(
            new MedicamentsQueryResult(
                Medicaments: records));
    }

    public async Task<Result<InjectionsQueryResult>> GetInjectionDataFromStoredProcedureAsync(
        int medicamentUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expressionForInjDates = "EXEC sp26_onk_category_get_inj_dates @lekPrUid";
        string expressionForInjections = "EXEC sp26_onk_category_get_injections @lekPrUid";

        var dates = await dbContext.InjDates.FromSqlRaw(expressionForInjDates, [new SqlParameter("@lekPrUid", medicamentUid)]).ToListAsync();
        var injectons = await dbContext.Injections.FromSqlRaw(expressionForInjections, [new SqlParameter("@lekPrUid", medicamentUid)]).ToListAsync();

        return Result<InjectionsQueryResult>.Success(
            new InjectionsQueryResult(
                InjDates: dates,
                Injs: injectons));
    }
}
