using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.DbEntities.References;
using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class InsuranceReferenceDataProvider(
    DbContextFactory dbContextFactory) : IInsuranceReferenceDataProvider
{
    public async Task<IReadOnlyCollection<InsuranceReferenceDto>> GetByKeysAsync(
        IReadOnlyCollection<string> keys, 
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<InsuranceDbEntity>()
            .Where(x => keys.Contains(x.InsuranceCode))
            .Select(x => new InsuranceReferenceDto(x.InsuranceCode, x.InsuranceShortname))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
