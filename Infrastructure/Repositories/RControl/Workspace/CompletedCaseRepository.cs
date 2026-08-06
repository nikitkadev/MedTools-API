using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Dtos.RControl.Workspace;
using Core.Dtos.RControl.Categories.MedicalCase;
using Core.Interfaces.RControl.Repositories.Workspace;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.Workspace;

public class CompletedCaseRepository(
    DbContextFactory dbContextFactory) : ICompletedCaseRepository
{
    public async Task<CompletedCaseDetailsDto?> GetCompletedCaseDetailsAsync(
        int completedCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var results = await dbContext
            .Set<CompletedCaseDetailsDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_completed_case_details @pCompletedCaseUid={completedCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var completedCaseDetails = results.FirstOrDefault();

        return completedCaseDetails;
        
    }

    public async Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        int invoiceUid, 
        int page, 
        int pageSize, 
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var totalCountParam = new SqlParameter("@total_count", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        var completedCases = await dbContext
            .Set<CompletedCaseListItemDto>()
            .FromSqlRaw(
                sql: "EXEC sp26_get_z_sl_data @schet_uid, @skip, @take, @search, @total_count OUTPUT",
                parameters: [
                        new SqlParameter("@schet_uid", invoiceUid),
                        new SqlParameter("@skip", pageSize * (page -1)),
                        new SqlParameter("@take", pageSize),
                        new SqlParameter("@search", string.Empty),
                        totalCountParam
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<CompletedCaseListItemDto>(
            Records: completedCases,
            TotalCount: (int)totalCountParam.Value);
    }

}