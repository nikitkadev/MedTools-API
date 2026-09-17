using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class DiseasesReferenceDataProvider(
    DbContextFactory dbContextFactory) : IDiseasesReferenceDataProvider
{
    public async Task<IReadOnlyCollection<DiseaseCharacterReferenceDto>> GetDiseaseCharacterReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseCharacterDbEntity>()
            .Where(x => x.CharacterName != null)
            .Select(x => new DiseaseCharacterReferenceDto(
                Id: x.CharacterId,
                Name: x.CharacterName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<DiseaseOutcomeReferenceDto>> GetDiseaseOutcomeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseOutcomeDbEntity>()
            .Select(x => new DiseaseOutcomeReferenceDto(
                Id: x.OutcomeId,
                Name: x.OutcomeName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}