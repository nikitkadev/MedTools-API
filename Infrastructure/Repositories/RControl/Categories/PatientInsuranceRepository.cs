using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.Categories.PatientInsurance;
using Core.Interfaces.RControl.Repositories.Categories;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.Categories;

public class PatientInsuranceRepository(
    DbContextFactory dbContextFactory) : IPatientInsuranceRepository
{

    public PatientDto? GetPatient(
        int medicalCaseUid, 
        TargetDbType targetDb)
    {
        using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var patient = dbContext
            .Set<PatientDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_patient_insurance_get_patient @pMedicalCaseUid={medicalCaseUid}")
            .AsEnumerable()
            .FirstOrDefault();

        return patient;
    }

    public InsuranceDto? GetInsurance(
        int medicalCaseUid, 
        TargetDbType targetDb)
    {
        using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var insurance = dbContext
            .Set<InsuranceDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_patient_insurance_get_insurance @pMedicalCaseUid={medicalCaseUid}")
            .AsEnumerable()
            .FirstOrDefault();

        return insurance;
    }

}