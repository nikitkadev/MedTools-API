using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.RControl.Oncology;
using Core.Dtos.RControl.Categories.Oncology;
using Core.Interfaces.RControl.Repositories.Oncology;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.RControl.Oncology;

public class OncologyRepository(
    DbContextFactory dbContextFactory) : IOncologyRepository
{
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

    public async Task<IReadOnlyCollection<ContraindicationDto>> GetContraindicationsAsync(
        int oncologyCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var contraindications = await dbContext
            .Set<ContraindicationDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_contraindications @pOncologyCaseUid={oncologyCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return contraindications;
    }

    public async Task<IReadOnlyCollection<DiagnosticsListItemDto>> GetDiagnosticsAsync(
        int oncologyCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var diagnosticsRecords = await dbContext
            .Set<DiagnosticsListItemDto>()
            .FromSqlInterpolated($"EXEC  mt_rcontrol_get_diagnostics_records @pOncologyCaseUid={oncologyCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return diagnosticsRecords;
    }

    public async Task<IReadOnlyCollection<OncologyServiceDto>> GetOncologyServicesAsync(
        int oncologyCaseUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var oncologyServices = await dbContext
            .Set<OncologyServiceDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_oncology_services @pOncologyCaseUid={oncologyCaseUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return oncologyServices;
    }

    public async Task<IReadOnlyCollection<MedicationDto>> GetMedicationsAsync(
        int oncologyServiceUid, 
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicaments = await dbContext
            .Set<MedicationDto>()
            .FromSqlInterpolated($"EXEC mt_rcontrol_get_medications @pOncologyServiceUid={oncologyServiceUid}")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicaments;
    }
}