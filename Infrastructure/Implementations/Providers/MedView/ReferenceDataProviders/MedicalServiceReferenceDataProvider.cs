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
    public async Task<IReadOnlyCollection<DrugIdentifierReferenceDto>> GetDrugIdentifierReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<DrugIdentifierDbEntity>()
            .Where(x => x.DrugIdentifierId != null && x.DrugIdentifierName != null && x.DrugIdentifierName.StartsWith(search))
            .Select(x => new DrugIdentifierReferenceDto(
                Id: x.DrugIdentifierId!,
                Name: x.DrugIdentifierName!))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

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

    public async Task<IReadOnlyCollection<InterruptedCasePaymentReasonReferenceDto>> GetInterruptedCasePaymentReasonReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<InterruptedCasePaymentReasonDbEntity>()
            .Where(x => x.InterruptedCasePaymentReasonName != null)
            .Select(x => new InterruptedCasePaymentReasonReferenceDto(
                Id: x.InterruptedCasePaymentReasonId,
                Name: x.InterruptedCasePaymentReasonName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<MedicalServiceReferenceDto>> GetMedicalServiceReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<MedicalServiceDbEntity>()
            .Where(x => x.ServiceName != null && (x.ServiceName.StartsWith(search) || x.ServiceCode.StartsWith(search)))
            .Select(x => new MedicalServiceReferenceDto(
                Id: x.ServiceId,
                Code: x.ServiceCode,
                Name: x.ServiceName!))
            .Take(30)
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

    public async Task<IReadOnlyCollection<ProvidedServiceReferenceDto>> GetProvidedServiceReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<ProvidedServiceDbEntity>()
            .Where(x => x.ProvidedServiceId != null && x.ProvidedServiceName != null && (x.ProvidedServiceId.StartsWith(search) || x.ProvidedServiceName.StartsWith(search)))
            .Select(x => new ProvidedServiceReferenceDto(
                Id: x.ProvidedServiceId!,
                Name: $"{x.ProvidedServiceId!} — {x.ProvidedServiceName!}"))
            .Take(30)
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

    public async Task<IReadOnlyCollection<ReferralTypeReferenceDto>> GetReferralTypeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<ReferralTypeDbEntity>()
            .Where(x => x.ReferralName != null)
            .Select(x => new ReferralTypeReferenceDto(
                Id: x.ReferralId,
                Name: x.ReferralName!))
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

    public async Task<IReadOnlyCollection<TherapyRegimenReferenceDto>> GetTherapyRegimenReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<TherapyRegimenDbEntity>()
            .Where(x => x.TherapyRegimenName != null && x.TherapyRegimenName.StartsWith(search))
            .Select(x => new TherapyRegimenReferenceDto(
                Id: x.TherapyRegimenId,
                Name: x.TherapyRegimenName!))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
