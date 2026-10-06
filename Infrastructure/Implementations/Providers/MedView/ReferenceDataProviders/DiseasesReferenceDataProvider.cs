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

    public async Task<IReadOnlyCollection<DiseaseClassReferenceDto>> GetDiseaseClassReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseClassDbEntity>()
            .Where(x => x.ClassName != null
                && x.StartingDiseasePrefix != null
                && x.EndingDiseasePrefix != null
                && x.ClassName != "Нет")
            .Select(x => new DiseaseClassReferenceDto(
                Id: x.Uid,
                Name: $"{x.StartingDiseasePrefix!}..{x.EndingDiseasePrefix!} — {x.ClassName!}"))
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

    public async Task<IReadOnlyCollection<DiseaseReferenceDto>> GetDiseaseReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseDbEntity>()
            .Where(x => (x.DiseaseCode != null && x.DiseaseCode != "000")
                && x.DiseaseName != null
                && (x.DiseaseCode.StartsWith(search) || x.DiseaseName.StartsWith(search)))
            .Select(x => new DiseaseReferenceDto(
                Id: x.DiseaseCode!,
                Name: x.DiseaseName!))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<DiseaseStageReferenceDto>> GetDiseaseStageReferencesAsync(
        string Search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseStageDbEntity>()
            .Where(x => x.StageName != null && x.StageName != "Нет" && x.StageName.StartsWith(Search))
            .Select(x => new DiseaseStageReferenceDto(
                Id: x.StageName!))
            .Distinct()
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<DiseaseSubClassReferenceDto>> GetDiseaseSubClassReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DiseaseSubClassDbEntity>()
            .Where(x => x.SubClassName != null 
                && x.StartingDiseasePrefix != null 
                && x.EndingDiseasePrefix != null)
            .Select(x => new DiseaseSubClassReferenceDto(
                Id: x.Uid,
                Name: $"{x.StartingDiseasePrefix}..{x.EndingDiseasePrefix} — {x.SubClassName}"))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}