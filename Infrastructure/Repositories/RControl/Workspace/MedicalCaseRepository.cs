using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.Workspace;
using Core.Dtos.RControl.Categories.MedicalCase;
using Core.Interfaces.RControl.Repositories.Workspace;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.Workspace;

public class MedicalCaseRepository(
    DbContextFactory dbContextFactory) : IMedicalCaseRepository
{
    public async Task<IReadOnlyCollection<ConsultationDto>> GetConsultationsAsync(
        int medicalCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var consulations = await dbContext
            .Set<ConsultationDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_consulations @pMedicalCaseUid={medicalCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return consulations;
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

    public async Task<IReadOnlyCollection<MedicalCaseListItemDto>> GetMedicalCaseListItemsAsync(
        int completedCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalCases = await dbContext
            .Set<MedicalCaseListItemDto>()
            .FromSqlInterpolated($"EXEC sp26_get_sl_data @zSlUid={completedCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalCases;
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

}