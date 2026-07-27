using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using Infrastructure.Factories;

using Core.Dtos;
using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class InvoiceSummaryRepository(DbContextFactory dbContextFactory) : IInvoiceSummaryRepository
{
    public async Task<Result<InvoiceSummaryQueryResult>> GetFromStoredProcedureAsync(
        int schetUid, 
        TargetDbType targetDb)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);
        await using var connection = dbContext.Database.GetDbConnection(); 

        if(connection.State != System.Data.ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        await using var command = connection.CreateCommand();
        
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "sp26_get_z_slsvod";
        command.Parameters.Add(new SqlParameter("schet_uid", schetUid));

        await using var reader = command.ExecuteReader();

        var result = new List<InvoiceSummaryQueryResult>();

        while(await reader.ReadAsync())
        {
            result.Add(new InvoiceSummaryQueryResult(
                Filename: reader.GetString(reader.GetOrdinal("schet_filename")),
                SchetUid: reader.GetInt32(reader.GetOrdinal("schet_uid")),
                UploadDate: reader.GetDateTime(reader.GetOrdinal("schet_uploaddate")),
                Summav: reader.GetDecimal(reader.GetOrdinal("sumv")),
                Summap: reader.GetDecimal(reader.GetOrdinal("tfoms_sump")),
                SankMek: reader.GetDecimal(reader.GetOrdinal("tfoms_sank_mek")),
                SankMee: reader.GetDecimal(reader.GetOrdinal("tfoms_sank_mee")),
                SankEkmp: reader.GetDecimal(reader.GetOrdinal("tfoms_sank_ekmp")),
                SmoSummap: reader.GetDecimal(reader.GetOrdinal("smo_sump")),
                SmoSankMek: reader.GetDecimal(reader.GetOrdinal("smo_sank_mek")),
                SmoSankMee: reader.GetDecimal(reader.GetOrdinal("smo_sank_mee")),
                SmoSankEkmp: reader.GetDecimal(reader.GetOrdinal("smo_sank_ekmp"))));
        }

        await reader.CloseAsync();

        return Result<InvoiceSummaryQueryResult>.Success(result[0]);
    }
}
