using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Dtos;
using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories;

using Infrastructure.Factories;


namespace Infrastructure.Repositories;

public class CasesRepository(
    DbContextFactory dbContextFactory) : ICasesRepository
{
    public async Task<Result<CasesQueryResult>> GetFromStorageProcedureAsync(
        int zSlUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var connection = dbContext.Database.GetDbConnection();

        if(connection.State != System.Data.ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        using var command = connection.CreateCommand();

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "sp26_get_sl_data";
        command.Parameters.Add(new SqlParameter("zSlUid", zSlUid));

        await using var reader = command.ExecuteReader();

        var result = new List<CaseDto>();

        while(await reader.ReadAsync())
        {
            result.Add(
                new CaseDto(
                    Uid: reader.GetInt32(reader.GetOrdinal("uid")),
                    Profil: reader.IsDBNull(reader.GetOrdinal("profil")) ? null : reader.GetInt32(reader.GetOrdinal("profil")),
                    Det: reader.GetInt16(reader.GetOrdinal("det")),
                    Prvs: reader.GetInt32(reader.GetOrdinal("prvs")),
                    StartingAt: reader.GetDateTime(reader.GetOrdinal("date_1")),
                    EndingAt: reader.GetDateTime(reader.GetOrdinal("date_2")),
                    Ds1: reader.GetString(reader.GetOrdinal("ds1")),
                    EdCol: reader.IsDBNull(reader.GetOrdinal("ed_col")) ? null : reader.GetDecimal(reader.GetOrdinal("ed_col")),
                    Tarif: reader.IsDBNull(reader.GetOrdinal("tarif")) ? null : reader.GetDecimal(reader.GetOrdinal("tarif")),
                    SumM: reader.GetDecimal(reader.GetOrdinal("sum_m")),
                    Sump: reader.IsDBNull(reader.GetOrdinal("sump")) ? null : reader.GetDecimal(reader.GetOrdinal("sump")),
                    SmoSump: reader.IsDBNull(reader.GetOrdinal("smo_sump")) ? null : reader.GetDecimal(reader.GetOrdinal("smo_sump"))));

        }

        return Result<CasesQueryResult>.Success(new CasesQueryResult(result));
    }
}
