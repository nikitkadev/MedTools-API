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

        var insuranceReferences = await dbContext
            .Set<InsuranceDbEntity>()
            .ToListAsync(cancellationToken: cancellationToken);

        var result = keys
            .Join(
                insuranceReferences,
                code => code,
                insurance => insurance.InsuranceCode,
                (code, insurance) => new InsuranceReferenceDto(
                    Code: code, 
                    Name: insurance.InsuranceShortname))
            .ToList();

        return result;
    }
}
