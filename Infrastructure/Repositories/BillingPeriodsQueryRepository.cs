using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Dtos;
using Core.Enums;
using Core.Common;

using Infrastructure.Factories;
using Core.Interfaces.Repositories.Filters;

namespace Infrastructure.Repositories;

public class BillingPeriodsQueryRepository(
    DbContextFactory dbContextFactory) : IBillingPeriodsQueryRepository
{
    public async Task<Result<BillingPeriodsQueryResult>> GetFromStoredProcedureAsync(
        TargetDbType targetDbType, 
        string orgCode)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDbType);
        var connection = dbContext.Database.GetDbConnection();

        if(connection.State != System.Data.ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        var command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "sp26_get_period";

        command.Parameters.Add(new SqlParameter("@code_mo", orgCode));

        await using var reader = await command.ExecuteReaderAsync();

        var result = new List<BillingPeriodDto>();

        while (await reader.ReadAsync())
        {
            result.Add(new BillingPeriodDto(
                Year: reader.GetInt32(reader.GetOrdinal("year_schet")),
                Month: reader.GetByte(reader.GetOrdinal("month_schet"))));
        }

        return Result<BillingPeriodsQueryResult>.Success(new BillingPeriodsQueryResult(result));
    }
}
