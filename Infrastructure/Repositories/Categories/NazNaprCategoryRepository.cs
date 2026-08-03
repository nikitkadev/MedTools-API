using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.NazNapr;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Categories;

public class NazNaprCategoryRepository(
    DbContextFactory dbContextFactory) : INazNaprCategoryRepository
{
    public async Task<Result<NazNaprQueryResult>> GetDataAsync(
        int sluchUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expressionForPurposes = "EXEC sp26_naznapr_category_get_purposes @sluchUid";
        string expressionForDirections = "EXEC sp26_naznapr_category_get_directions @sluchUid";

        var purposes = await dbContext.Purposes.FromSqlRaw(expressionForPurposes, [new SqlParameter("@sluchUid", sluchUid)]).ToListAsync();
        var directions = await dbContext.Directions.FromSqlRaw(expressionForDirections, [new SqlParameter("@sluchUid", sluchUid)]).ToListAsync();

        return Result<NazNaprQueryResult>.Success(
            new NazNaprQueryResult(
                Purposes: purposes,
                Directions: directions));

    }
}
