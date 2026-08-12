using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.OncologyCases;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class OncologyCaseRepository(
    DbContextFactory dbContextFactory) : IOncologyCaseRepository
{
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

}