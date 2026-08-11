using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.RControl.OncologyServices;
using Core.Interfaces.Repositories.RControl;

using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Repositories.RControl;

public class OncologyServiceRepository(
    DbContextFactory dbContextFactory) : IOncologyServiceRepository
{
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