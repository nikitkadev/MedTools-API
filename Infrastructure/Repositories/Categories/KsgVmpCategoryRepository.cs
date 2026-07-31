using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Dtos.Categories.KsgVmp;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Categories;

public class KsgVmpCategoryRepository(
    DbContextFactory dbContextFactory) : IKsgVmpCategoryRepository
{
    public async Task<Result<KsgVmpCardsDataQueryResult>> GetCardsDataAsync(
        int sluchUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expressionForKsgKpg = "EXEC sp26_ksgvmp_category_get_ksgkpg @sluchUid";
        string expressionForVmp = "EXEC sp26_ksgvmp_category_get_vmp @sluchUid";

        var ksgKpgRecord = dbContext.KsgKpgs
            .FromSqlRaw(expressionForKsgKpg, [new SqlParameter("@sluchUid", sluchUid)])
            .AsEnumerable()
            .FirstOrDefault();

        var vmpRecord = dbContext.Vmps
            .FromSqlRaw(expressionForVmp, [new SqlParameter("@sluchUid", sluchUid)])
            .AsEnumerable()
            .FirstOrDefault();

        return Result<KsgVmpCardsDataQueryResult>.Success(
            new KsgVmpCardsDataQueryResult(
                KsgKpg: ksgKpgRecord,
                Vmp: vmpRecord));
    }
}
