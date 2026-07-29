using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Common;
using Core.Enums;
using Core.Dtos.Categories.Onkology;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Categories;

public class OnkologyCategoryRepository(
    DbContextFactory dbContextFactory) : IOnkologyCategoryRepository
{
    public async Task<Result<OnkSluchQueryResult>> GetOnkologyCaseFromStoredProcedureAsync(
        int sluchUid,
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expression = "EXEC sp26_onk_category_get_onk_sluch @sluchUid";

        var records = await dbContext.OnkCases.FromSqlRaw(expression, [new SqlParameter("@sluchUid", sluchUid)]).ToListAsync();
        var record = records.FirstOrDefault();

        if (record is null)
        {
            return Result<OnkSluchQueryResult>.Failure("Данных не найдено!");
        }

        return Result<OnkSluchQueryResult>.Success(new OnkSluchQueryResult(record));
    }
}
