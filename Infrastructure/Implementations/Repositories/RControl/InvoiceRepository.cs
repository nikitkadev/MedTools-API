using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Common.Results;
using Core.Dtos.RControl.Invoices;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class InvoiceRepository(
    DbContextFactory dbContextFactory) : IInvoiceRepository
{
    public async Task<PagedResult<InvoiceListItemDto>> GetInvoiceListItemsAsync(
        string medicalOrganizationCode,
        int year,
        int month,
        int page,
        int pageSize,
        string searchString,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var totalParam = new SqlParameter("@total", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        var invoices = await dbContext
            .Set<InvoiceListItemDto>()
            .FromSqlRaw(
                sql: "EXEC sp26_get_nschet @code_mo, @year, @month, @take, @skip, @search, @total OUTPUT",
                parameters: [
                        new SqlParameter("@code_mo", medicalOrganizationCode),
                        new SqlParameter("@year", year),
                        new SqlParameter("@month", month),
                        new SqlParameter("@take", pageSize),
                        new SqlParameter("@skip", pageSize * (page - 1)),
                        new SqlParameter("@search", searchString),
                        totalParam
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<InvoiceListItemDto>(
            Records: invoices,
            TotalCount: (int)totalParam.Value);
    }

    public async Task<InvoiceSummaryDto?> GetInvoiceSummaryAsync(
        int invoiceUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<InvoiceSummaryDto>()
            .FromSqlInterpolated($"EXEC sp26_get_z_slsvod @schet_uid={invoiceUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var invoiceSummary = result.FirstOrDefault();

        return invoiceSummary;
    }

    public async Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        int invoiceUid,
        int page,
        int pageSize,
        string searchString,
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
                        new SqlParameter("@search", searchString),
                        totalCountParam
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<CompletedCaseListItemDto>(
            Records: completedCases,
            TotalCount: (int)totalCountParam.Value);
    }

}
