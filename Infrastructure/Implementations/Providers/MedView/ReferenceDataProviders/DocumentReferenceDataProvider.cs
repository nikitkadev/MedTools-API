using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.DbEntities.References;
using Infrastructure.Database.Factories;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class DocumentReferenceDataProvider(
    DbContextFactory dbContextFactory) : IDocumentReferenceDataProvider
{
    public async Task<IReadOnlyCollection<InsurancePolicyTypeReferenceDto>> GetInsurancePolicyTypesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var insurancePolicyTypes = await dbContext
            .Set<InsurancePolicyTypeDbEntity>()
            .ToListAsync(cancellationToken: cancellationToken);

        return [.. insurancePolicyTypes
            .Select(x => new InsurancePolicyTypeReferenceDto(TypeId: x.DocumentId, Name: x.DocumentName))];
    }
}
