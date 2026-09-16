using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class MedicalCareReferenceDataProvider(
    DbContextFactory dbContextFactory) : IMedicalCareReferenceDataProvider
{
    public async Task<IReadOnlyCollection<BedProfileReferenceDto>> GetBedProfileReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<BedProfileDbEntity>()
            .Select(x => new BedProfileReferenceDto(
                BedProfileId: x.BedProfileId,
                BedProfileName: x.BedProfileName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<CareConditionReferenceDto>> GetCareConditionReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<CareConditionDbEntity>()
            .Select(x => new CareConditionReferenceDto(
                Id: x.ConditionId,
                Name: x.ConditionName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<CareFormReferenceDto>> GetCareFormReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<CareFormDbEntity>()
            .Where(x => x.CareFormName != null)
            .Select(x => new CareFormReferenceDto(
                Id: x.CareFormId,
                Name: x.CareFormName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<MedicalCareProfileReferenceDto>> GetMedicalCareProfileReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<MedicalCareProfileDbEntity>()
            .Select(x => new MedicalCareProfileReferenceDto(
                ProfileId: x.ProfileId,
                ProfileName: x.ProfileName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<MedicalCareTypeReferenceDto>> GetMedicalCareTypeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<MedicalCareTypeDbEntity>()
            .Select(x => new MedicalCareTypeReferenceDto(
                Id: x.Uid,
                Name: x.MedicalCareName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<PhysicianSpecialtyReferenceDto>> GetPhysicianSpecialtyReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<PhysicianSpecialtyDbEntity>()
            .Select(x => new PhysicianSpecialtyReferenceDto(
                Id: x.SpecialityId,
                Name: x.SpecialityPostname == null || x.SpecialityPostname == string.Empty ? x.SpecialityName : $"{x.SpecialityName}" + " " + $"({x.SpecialityPostname})"))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}