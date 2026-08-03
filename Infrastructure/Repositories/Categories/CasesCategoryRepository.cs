using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Dtos;
using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Categories;

public class CasesCategoryRepository(
    DbContextFactory dbContextFactory) : ICasesCategoryRepository
{
    public async Task<Result<CategoryCasesQueryResult>> GetFromStoredProcedureAsync(
        int sluchUid, 
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
        command.CommandText = "sp26_get_all_cases_category_data";
        command.Parameters.Add(new SqlParameter("slUid", sluchUid));

        await using var reader = await command.ExecuteReaderAsync();

        var cases = new List<CaseCategoryDto>();
        var finishedCases = new List<FinishedCaseCategoryDto>();

        while(await reader.ReadAsync())
        {
            cases.Add(
                new CaseCategoryDto(
                    Profil: reader.GetInt32(reader.GetOrdinal("profil")),
                    Lpu1: reader.IsDBNull(reader.GetOrdinal("lpu_1")) ? null : reader.GetString(reader.GetOrdinal("lpu_1")),
                    Podr: reader.IsDBNull(reader.GetOrdinal("podr")) ? null : reader.GetInt64(reader.GetOrdinal("podr")),
                    Prvs: reader.GetInt32(reader.GetOrdinal("prvs")),
                    Det: reader.GetInt16(reader.GetOrdinal("det")),
                    PCel: reader.IsDBNull(reader.GetOrdinal("p_cel")) ? null : reader.GetString(reader.GetOrdinal("p_cel")),
                    ProfilK: reader.IsDBNull(reader.GetOrdinal("profil_k")) ? null : reader.GetInt32(reader.GetOrdinal("profil_k")),
                    NHistory: reader.GetString(reader.GetOrdinal("history")),
                    PPer: reader.IsDBNull(reader.GetOrdinal("p_per")) ? null : reader.GetInt16(reader.GetOrdinal("p_per")),
                    Reab: reader.IsDBNull(reader.GetOrdinal("reab")) ? null : reader.GetByte(reader.GetOrdinal("reab")),
                    Date1: reader.GetDateTime(reader.GetOrdinal("date_1")),
                    Date2: reader.GetDateTime(reader.GetOrdinal("date_2")),
                    EdCol: reader.IsDBNull(reader.GetOrdinal("ed_col")) ? null : reader.GetDecimal(reader.GetOrdinal("ed_col")),
                    KD: reader.IsDBNull(reader.GetOrdinal("kd")) ? null : reader.GetInt32(reader.GetOrdinal("kd")),
                    LpuLevel: reader.IsDBNull(reader.GetOrdinal("lpu_level")) ? null : reader.GetString(reader.GetOrdinal("lpu_level")),
                    Ds0: reader.IsDBNull(reader.GetOrdinal("ds0")) ? null : reader.GetString(reader.GetOrdinal("ds0")),
                    DsOnk: reader.IsDBNull(reader.GetOrdinal("ds_onk")) ? null : reader.GetByte(reader.GetOrdinal("ds_onk")),
                    Iddokt: reader.GetString(reader.GetOrdinal("iddokt")),
                    Wei: reader.IsDBNull(reader.GetOrdinal("wei")) ? null : reader.GetDecimal(reader.GetOrdinal("wei")),
                    Ds1: reader.GetString(reader.GetOrdinal("ds1")),
                    CZab: reader.IsDBNull(reader.GetOrdinal("c_zab")) ? null : reader.GetByte(reader.GetOrdinal("c_zab")),
                    Comentsl: reader.IsDBNull(reader.GetOrdinal("comentsl")) ? null : reader.GetString(reader.GetOrdinal("comentsl"))));

            finishedCases.Add(
                new FinishedCaseCategoryDto(
                    Lpu: reader.GetString(reader.GetOrdinal("lpu")),
                    NprMo: reader.IsDBNull(reader.GetOrdinal("npr_mo")) ? null : reader.GetString(reader.GetOrdinal("npr_mo")),
                    NprDate: reader.IsDBNull(reader.GetOrdinal("npr_date")) ? null : reader.GetDateTime(reader.GetOrdinal("npr_date")),
                    UslOk: reader.GetInt32(reader.GetOrdinal("usl_ok")),
                    VidPom: reader.GetInt32(reader.GetOrdinal("vidpom")),
                    Idsp: reader.GetInt16(reader.GetOrdinal("idsp")),
                    ForPom: reader.GetByte(reader.GetOrdinal("for_pom")),
                    DateZ1: reader.GetDateTime(reader.GetOrdinal("date_z_1")),
                    DateZ2: reader.GetDateTime(reader.GetOrdinal("date_z_2")),
                    KdZ: reader.IsDBNull(reader.GetOrdinal("kd_z")) ? null : reader.GetInt32(reader.GetOrdinal("kd_z")),
                    Rslt: reader.GetInt32(reader.GetOrdinal("rslt")),
                    VbP: reader.IsDBNull(reader.GetOrdinal("vb_p")) ? null : reader.GetByte(reader.GetOrdinal("vb_p")),
                    RsltD: reader.IsDBNull(reader.GetOrdinal("rslt_d")) ? null : reader.GetInt32(reader.GetOrdinal("rslt_d")),
                    POtk: reader.IsDBNull(reader.GetOrdinal("p_otk")) ? null : reader.GetByte(reader.GetOrdinal("p_otk")),
                    Vbr: reader.IsDBNull(reader.GetOrdinal("vbr")) ? null : reader.GetByte(reader.GetOrdinal("vbr")),
                    Ishod: reader.GetInt32(reader.GetOrdinal("ishod"))));
        }

        return Result<CategoryCasesQueryResult>.Success(new CategoryCasesQueryResult(
            Case: cases[0],
            FinishedCase: finishedCases[0]));
    }
}
