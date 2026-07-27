using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Dtos;
using Core.Enums;
using Core.Common;
using Core.Interfaces.Repositories.Categories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Categories;

public class PatientSmoCategoryRepository(
    DbContextFactory dbContextFactory) : IPatientSmoCategoryRepository
{
    public async Task<Result<PatientSmoQueryResult>> GetFromStoredProcedureAsync(
        int sluchUid, 
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
        command.CommandText = "sp26_get_patient_smo_category_data";
        command.Parameters.Add(new SqlParameter("slUid", sluchUid));

        await using var reader = await command.ExecuteReaderAsync();

        var patients = new List<PatientDto>();
        var smo = new List<SmoDto>();

        while(await reader.ReadAsync())
        {
            patients.Add(
                new PatientDto(
                    Surname: reader.GetString(reader.GetOrdinal("fam")),
                    Name: reader.GetString(reader.GetOrdinal("im")),
                    Patronymic: reader.GetString(reader.GetOrdinal("ot")),
                    Sex: reader.GetByte(reader.GetOrdinal("w")),
                    Birthday: reader.GetDateTime(reader.GetOrdinal("dr")),
                    RepresentativeSurname: reader.IsDBNull(reader.GetOrdinal("fam_p")) ? null : reader.GetString(reader.GetOrdinal("fam_p")),
                    RepresentativeName: reader.IsDBNull(reader.GetOrdinal("im_p")) ? null : reader.GetString(reader.GetOrdinal("im_p")),
                    RepresentativePatronymic: reader.IsDBNull(reader.GetOrdinal("ot_p")) ? null : reader.GetString(reader.GetOrdinal("ot_p")),
                    RepresentativeSex: reader.IsDBNull(reader.GetOrdinal("w_p")) ? null : reader.GetByte(reader.GetOrdinal("w_p")),
                    RepresentativeBithday: reader.IsDBNull(reader.GetOrdinal("dr_p")) ? null : reader.GetDateTime(reader.GetOrdinal("dr_p")),
                    DocumentType: reader.IsDBNull(reader.GetOrdinal("doctype")) ? null : reader.GetString(reader.GetOrdinal("doctype")),
                    DocumentSeries: reader.IsDBNull(reader.GetOrdinal("docser")) ? null : reader.GetString(reader.GetOrdinal("docser")),
                    DocumentNumber: reader.IsDBNull(reader.GetOrdinal("docnum")) ? null : reader.GetString(reader.GetOrdinal("docnum")),
                    IssueDate: reader.IsDBNull(reader.GetOrdinal("docdate")) ? null : reader.GetDateTime(reader.GetOrdinal("docdate")),
                    IssuedBy: reader.IsDBNull(reader.GetOrdinal("docorg")) ? null : reader.GetString(reader.GetOrdinal("docorg"))));

            smo.Add(
                new SmoDto(
                    SmoCode: reader.IsDBNull(reader.GetOrdinal("smo")) ? null : reader.GetString(reader.GetOrdinal("smo")),
                    SmoName: reader.IsDBNull(reader.GetOrdinal("smo_nam")) ? null : reader.GetString(reader.GetOrdinal("smo_nam")),
                    SmoOGRN: reader.IsDBNull(reader.GetOrdinal("smo_ogrn")) ? null : reader.GetString(reader.GetOrdinal("smo_ogrn")),
                    SmoOKATO: reader.IsDBNull(reader.GetOrdinal("smo_ok")) ? null : reader.GetString(reader.GetOrdinal("smo_ok")),
                    PolisSeries: reader.IsDBNull(reader.GetOrdinal("spolis")) ? null : reader.GetString(reader.GetOrdinal("spolis")),
                    PolisNumber: reader.GetString(reader.GetOrdinal("npolis")),
                    PolisType: reader.GetByte(reader.GetOrdinal("vpolis")),
                    Enp: reader.IsDBNull(reader.GetOrdinal("enp")) ? null : reader.GetString(reader.GetOrdinal("enp"))));

        }

        return Result<PatientSmoQueryResult>.Success(new PatientSmoQueryResult(
            Patient: patients[0],
            SMO: smo[0]));

    }
}
