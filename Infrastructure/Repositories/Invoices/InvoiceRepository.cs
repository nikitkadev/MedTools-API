using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Common;
using Core.Dtos.Invoices;
using Core.Interfaces.Repositories.Invoices;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Invoices;

public class InvoiceRepository(DbContextFactory dbContextFactory) : IInvoiceRepository
{
    public async Task<PagedResult<IReadOnlyCollection<InvoiceDto>>> GetInvoicesAsync(
        string medicalOrganizationCode, 
        int year, 
        int month, 
        int page, 
        int pageSize, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var totalParam = new SqlParameter("@total", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        var invoices = await dbContext
            .Set<InvoiceDto>()
            .FromSqlRaw(
                sql: "EXEC sp26_get_nschet @code_mo, @year, @month, @take, @skip, @search, @total OUTPUT",
                parameters: [
                        new SqlParameter("@code_mo", medicalOrganizationCode),
                        new SqlParameter("@year", year),
                        new SqlParameter("@month", month),
                        new SqlParameter("@take", pageSize),
                        new SqlParameter("@skip", pageSize * (page - 1)),
                        new SqlParameter("@search", string.Empty),
                        totalParam
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<IReadOnlyCollection<InvoiceDto>>(
            Records: invoices,
            Count: (int)totalParam.Value);
    }
}
