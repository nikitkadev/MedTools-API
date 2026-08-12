using System.Data;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Common.Results;
using Core.Dtos.RControl.MedicalCases;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class MedicalCaseRepository(
    DbContextFactory dbContextFactory) : IMedicalCaseRepository
{
    public async Task<PatientDto?> GetPatientAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<PatientDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_patient @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var patient = result.FirstOrDefault();

        return patient;
    }

    public async Task<InsuranceDto?> GetInsuranceAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<InsuranceDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_insurance @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var insurance = result.FirstOrDefault();

        return insurance;
    }

    public async Task<IReadOnlyCollection<ProvidedServiceListItemDto>> GetProvidedServicesAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var providedServices = await dbContext
            .Set<ProvidedServiceListItemDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_provided_services @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return providedServices;
    }

    public async Task<MedicalCaseDetailsDto?> GetMedicalCaseDetailsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<MedicalCaseDetailsDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_medical_case_details @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var medicalCaseDetails = result.FirstOrDefault();

        return medicalCaseDetails;
    }

    public async Task<IReadOnlyCollection<ConsultationDto>> GetConsultationsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var consultations = await dbContext
            .Set<ConsultationDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_consultations @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return consultations;
    }

    public async Task<ClinicalGroupDto?> GetClinicalGroupAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<ClinicalGroupDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_clinical_group @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var clinicalGroup = result.FirstOrDefault();

        return clinicalGroup;
    }

    public async Task<HighTechMedicalCareDto?> GetHighTechMedicalCareAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<HighTechMedicalCareDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_high_tech_medical_care @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var highTechMedicalCare = result.FirstOrDefault();

        return highTechMedicalCare;
    }

    public async Task<IReadOnlyCollection<ReferralDto>> GetReferralsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var referrals = await dbContext
            .Set<ReferralDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_referrals @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return referrals;
    }

    public async Task<IReadOnlyCollection<PrescriptionDto>> GetPrescriptionsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var prescriptions = await dbContext
            .Set<PrescriptionDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_prescriptions @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return prescriptions;
    }

    public async Task<PagedResult<DefectDto>> GetDefectsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        int page,
        int pageSize,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var totalCountParam = new SqlParameter("@totalCount", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        var defects = await dbContext
            .Set<DefectDto>()
            .FromSqlRaw(
                sql: "EXEC mt_rcontrol_get_defects @pMedicalCaseUid, @pSkip, @pTake, @totalCount OUTPUT",
                parameters: [
                    new SqlParameter("@pMedicalCaseUid", medicalCaseUid),
                    new SqlParameter("@pSkip", pageSize * (page - 1)),
                    new SqlParameter("@pTake", pageSize),
                    totalCountParam
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<DefectDto>(
            Records: defects,
            TotalCount: (int)totalCountParam.Value);
    }

    public async Task<IReadOnlyCollection<MedicalSanctionDto>> GetMedicalSanctionsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalSanctions = await dbContext
            .Set<MedicalSanctionDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_medical_sanctions @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalSanctions;
    }

    public async Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var result = await dbContext
            .Set<OncologyCaseDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_oncology_case @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var oncologyCase = result.FirstOrDefault();

        return oncologyCase;
    }

}