using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Implementations.Providers.MedView.AvailableKeysProviders;

public sealed class AvaliableKeysHelper(
    DbContextFactory dbContextFactory) : IAvaliableKeysHelper
{
    public async Task<IReadOnlyCollection<int>> GetAvailableDiseaseStageKeysAsync(
        IReadOnlyCollection<string> names,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseStageDbEntity>()
            .Where(x => names.Contains(x.StageName))
            .Select(x => x.StageId)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
