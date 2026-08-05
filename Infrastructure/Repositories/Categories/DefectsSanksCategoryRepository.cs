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
    public async Task<Result<DefectsQueryResult>> GetDefectsAsync(
        int sluchUid, 
        TargetDbType targetDb, 
        int page, 
        int pageSize)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expression = "EXEC sp26_get_sl_defects_by_sluchUid @sluchUid, @pSkip, @pTake, @total OUTPUT";

        var totalParam = new SqlParameter("@total", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        var records = await dbContext.Defects.FromSqlRaw(expression, [
                new SqlParameter("@sluchUid", sluchUid),
                new SqlParameter("@pSkip", pageSize * (page - 1)),
                new SqlParameter("@pTake", pageSize),
                totalParam
            ]).ToListAsync();

        return Result<DefectsQueryResult>.Success(
            new DefectsQueryResult(
                Defects: records,
                TotalItems: (int)totalParam.Value));

    }

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
