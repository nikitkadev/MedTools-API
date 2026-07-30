using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore
    ;
using Core.Dtos;
using Core.Enums;
using Core.Common;

using Infrastructure.Factories;
using Core.Interfaces.Repositories.MainField;

namespace Infrastructure.Repositories;

public class FinishedCasesRepository(
    DbContextFactory dbContextFactory) : IFinishedCasesRepository
{
    public async Task<Result<FinishedCasesQueryResult>> GetFromStoredProcedureAsync(
        int schetUid, 
        TargetDbType dbType, 
        int page, 
        int pageSize, 
        string searchString)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(dbType);
        var connection = dbContext.Database.GetDbConnection();

        if(connection.State != System.Data.ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        await using var command = connection.CreateCommand();

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "sp26_get_z_sl_data";

        var outputTotal = new SqlParameter("total_count", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        command.Parameters.Add(new SqlParameter("schet_uid", schetUid));
        command.Parameters.Add(new SqlParameter("skip", (page * pageSize) - pageSize));
        command.Parameters.Add(new SqlParameter("take", pageSize));
        command.Parameters.Add(new SqlParameter("globalSearchString", searchString));
        command.Parameters.Add(outputTotal);

        await using var reader = await command.ExecuteReaderAsync();

        var result = new List<FinishedCasesDto>();

        while(await reader.ReadAsync())
        {
            result.Add(new FinishedCasesDto(
                PacientUid: reader.GetInt32(reader.GetOrdinal("pcuid")),
                PersUid: reader.GetInt32(reader.GetOrdinal("psuid")),
                ZSlUid: reader.GetInt32(reader.GetOrdinal("zsluid")),
                PositionNumber: reader.GetInt64(reader.GetOrdinal("idcase")),
                RecordNumber: reader.GetInt64(reader.GetOrdinal("n_zap")),
                Surname: reader.GetString(reader.GetOrdinal("fam")),
                Name: reader.GetString(reader.GetOrdinal("im")),
                Patronymic: reader.GetString(reader.GetOrdinal("ot")),
                UslOk: reader.GetInt32(reader.GetOrdinal("usl_ok")),
                SPolis: reader.IsDBNull(reader.GetOrdinal("spolis")) ? null : reader.GetString(reader.GetOrdinal("spolis")),
                NPolis: reader.GetString(reader.GetOrdinal("npolis")),
                Sumv: reader.GetDecimal(reader.GetOrdinal("sumv")),
                Sump: reader.IsDBNull(reader.GetOrdinal("sump")) ? null : reader.GetDecimal(reader.GetOrdinal("sump")),
                SmoSump: reader.IsDBNull(reader.GetOrdinal("smo_sump")) ? null : reader.GetDecimal(reader.GetOrdinal("smo_sump"))));
        }

        await reader.CloseAsync();

        return Result<FinishedCasesQueryResult>.Success(new FinishedCasesQueryResult(
            FinisedCases: result,
            TotalRecords: (int)outputTotal.Value));
    }
}
