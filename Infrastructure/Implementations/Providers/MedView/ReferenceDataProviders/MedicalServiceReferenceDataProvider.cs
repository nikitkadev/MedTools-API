using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class MedicalServiceReferenceDataProvider(
    DbContextFactory dbContextFactory) : IMedicalServiceReferenceDataProvider
{
    public async Task<IReadOnlyCollection<DrugTherapyCycleReferenceDto>> GetDrugTherapyCycleReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DrugTherapyCycleDbEntity>()
            .Where(x => x.DrugTherapyCycleName != null)
            .Select(x => new DrugTherapyCycleReferenceDto(
                Id: x.DrugTherapyCycleId,
                Name: x.DrugTherapyCycleName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<DrugTherapyLineReferenceDto>> GetDrugTherapyLineReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DrugTherapyLineDbEntity>()
            .Where(x => x.DrugTherapyLineName != null)
            .Select(x => new DrugTherapyLineReferenceDto(
                Id: x.DrugTherapyLineId,
                Name: x.DrugTherapyLineName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
            
    }

    public async Task<IReadOnlyCollection<OncologyServiceTypeReferenceDto>> GetOncologyServiceTypeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<OncologyServiceTypeDbEntity>()
            .Where(x => x.ServiceName != null)
            .Select(x => new OncologyServiceTypeReferenceDto(
                Id: x.ServiceId,
                Name: x.ServiceName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<RadioTherapyTypeReferenceDto>> GetRadioTherapyTypeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<RadioTherapyTypeDbEntity>()
            .Where(x => x.RadioTherapyTypeName != null)
            .Select(x => new RadioTherapyTypeReferenceDto(
                Id: x.RadioTherapyTypeId,
                Name: x.RadioTherapyTypeName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<SurgicalTreatmentTypeReferenceDto>> GetSurgicalTreatmentTypeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<SurgicalTreatmentTypeDbEntity>()
            .Where(x => x.SurgicalTreatmentTypeName != null)
            .Select(x => new SurgicalTreatmentTypeReferenceDto(
                Id: x.SurgicalTreatmentTypeId,
                Name: x.SurgicalTreatmentTypeName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
