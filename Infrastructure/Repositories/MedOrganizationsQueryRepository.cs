using Microsoft.EntityFrameworkCore;

using Core.Dtos;
using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories;

public class MedOrganizationsQueryRepository(
    DbContextFactory dbContextFactory) : IMedOrganizationsQueryRepository
{
    public async Task<Result<MedOrganizationsQueryResult>> GetFromStoredProcedureAsync(TargetDbType dbType)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(dbType);
        var connection = dbContext.Database.GetDbConnection();

        if (connection.State != System.Data.ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        var command = connection.CreateCommand();

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "sp26_get_mo";

        using var reader = await command.ExecuteReaderAsync();

        var result = new List<MedOrganizationDto>();

        while (await reader.ReadAsync())
        {
            result.Add(
                new MedOrganizationDto(
                    Name: reader.GetString(reader.GetOrdinal("name_code")),
                    Code: reader.GetString(reader.GetOrdinal("code"))));

        }

        return Result<MedOrganizationsQueryResult>.Success(
            new MedOrganizationsQueryResult(result));

    }
}
