using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;
using Core.Dtos.RControl.Categories.KsgVmp;

namespace Infrastructure.Repositories.Categories;

public class KsgVmpCategoryRepository(
    DbContextFactory dbContextFactory) : IKsgVmpCategoryRepository
{

    public async Task<Result<KsgVmpTablesQueryResult>> GetTablesDataAsync(
        int ksgKpgUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expressionForCrits = "EXEC sp26_ksgvmp_category_get_crits @ksgKpgUid";
        string expressionForSlKoefs = "EXEC sp26_ksgvmp_category_get_sl_koefs @ksgKpgUid";

        var crits = await dbContext.Crits.FromSqlRaw(expressionForCrits, [new SqlParameter("@ksgKpgUid", ksgKpgUid)]).ToListAsync();
        var slKoefs = await dbContext.SlKoefs.FromSqlRaw(expressionForSlKoefs, [new SqlParameter("@ksgKpgUid", ksgKpgUid)]).ToListAsync();

        return Result<KsgVmpTablesQueryResult>.Success(
            new KsgVmpTablesQueryResult(
                Crits: crits,
                SlKoefs: slKoefs));
    }
}
