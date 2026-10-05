using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Interfaces.Providers.MedView;

using Infrastructure.Database.DbEntities.References;
using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Providers.MedView;


public sealed class DiseasesDataProvider(
    DbContextFactory dbContextFactory) : IDiseasesDataProvider
{
    public async Task<IReadOnlyCollection<string>> GetDiseasesByClassUidsAsync(
        IReadOnlyCollection<int> uids,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseDbEntity>()
            .Where(x => x.ClassCode.HasValue
                && uids.Contains(x.ClassCode.Value)
                && x.DiseaseCode != null)
            .Select(x => x.DiseaseCode!)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<string>> GetDiseasesBySubClassUidsAsync(
        IReadOnlyCollection<int> uids,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseDbEntity>()
            .Where(x => x.SubClassCode.HasValue
                && uids.Contains(x.SubClassCode.Value)
                && x.DiseaseCode != null)
            .Select(x => x.DiseaseCode!)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}