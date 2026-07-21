using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Dtos;
using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories;

public class InvoiceQueryRepository(
    DbContextFactory dbContextFactory) : IInvoiceQueryRepository
{
    public async Task<Result<InvoicesShortlyQueryResult>> GetShortlyAsync(
        string orgCode, 
        int year, 
        int month, 
        TargetDbType dbType, 
        int skip, 
        int take, 
        string searchString)
    {
        using var dbContext = dbContextFactory.CreateDbContext(dbType);
        var connection = dbContext.Database.GetDbConnection();

        if(connection.State != System.Data.ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        await using var command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "sp26_get_nschet";

        var outputTotal = new SqlParameter("total", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        command.Parameters.Add(new SqlParameter("code_mo", orgCode));
        command.Parameters.Add(new SqlParameter("year", year));
        command.Parameters.Add(new SqlParameter("month", month));
        command.Parameters.Add(new SqlParameter("skip", skip));
        command.Parameters.Add(new SqlParameter("take", take));
        command.Parameters.Add(new SqlParameter("globalSearchString", searchString));
        command.Parameters.Add(outputTotal);

        await using var reader = await command.ExecuteReaderAsync();

        var result = new List<InvoicesShortlyDto>();

        while (await reader.ReadAsync())
        {
            result.Add(
                new InvoicesShortlyDto(
                    InvoiceNumber: reader.GetString(reader.GetOrdinal("nschet")),
                    InvoiceDate: reader.GetDateTime(reader.GetOrdinal("dschet")),
                    InvoiceAmount: reader.GetDecimal(reader.GetOrdinal("summav")),
                    Cases: reader.GetInt32(reader.GetOrdinal("sd_z")),
                    Status: reader.GetInt16(reader.GetOrdinal("status"))));
        }

        return Result<InvoicesShortlyQueryResult>.Success(
            new InvoicesShortlyQueryResult(
                InvoicesShortlies: result,
                TotalRecords: (int)outputTotal.Value));

    }
}
