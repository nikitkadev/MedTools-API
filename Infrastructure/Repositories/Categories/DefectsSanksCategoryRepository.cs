using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;
using Core.Dtos.RControl.Categories.DefectsSanks;

namespace Infrastructure.Repositories.Categories;

public class DefectsSanksCategoryRepository(
    DbContextFactory dbContextFactory) : IDefectsSanksCategoryRepository
{
    public async Task<Result<SanksQueryResult>> GetSanksAsync(
        int sluchUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expression = "EXEC sp26_defects_sanks_category_get_sanks @sluchUid";

        var records = await dbContext.Sanks.FromSqlRaw(expression, [new SqlParameter("@sluchUid", sluchUid)]).ToListAsync();

        return Result<SanksQueryResult>.Success(
            new SanksQueryResult(
                Sanks: records));
    }
}
