using Microsoft.EntityFrameworkCore;


using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class PaymentReferenceDataProvider(
    DbContextFactory dbContextFactory) : IPaymentReferenceDataProvider
{
    public async Task<IReadOnlyCollection<ClinicalGroupReferenceDto>> GetClinicalGroupReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<ClinicalGroupDbEntity>()
            .Where(x => x.ClinicalGroupName != null && x.ClinicalGroupId.StartsWith(search))
            .Select(x => new ClinicalGroupReferenceDto(
                Id: x.ClinicalGroupId,
                Name: $"{x.ClinicalGroupId} — {x.ClinicalGroupName!}"))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<ComplexityCoefficientReferenceDto>> GetComplexityCoefficientReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<ComplexityCoefficientDbEntity>()
            .Where(x => x.ComplexityCoefficientName != null)
            .Select(x => new ComplexityCoefficientReferenceDto(
                Id: x.ComplexityCoefficientId,
                Name: x.ComplexityCoefficientName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<ControlTypeCodeReferenceDto>> GetControlTypeCodeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<ControlTypeCodeDbEntity>()
            .Where(x => x.ControlTypeCodeName != null)
            .Select(x => new ControlTypeCodeReferenceDto(
                Id: x.ControlTypeCodeId,
                Name: x.ControlTypeCodeName!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<PaymentMethodReferenceDto>> GetPaymentMethodReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<PaymentMethodDbEntity>()
            .Select(x => new PaymentMethodReferenceDto(
                Id: x.Uid,
                Name: x.PaymentMethodName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<RefusalReasonCodeReferenceDto>> GetRefusalReasonCodeReferencesAsync(
        string search,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<RefusalReasonCodeDbEntity>()
            .Where(x => x.RefusalReasonCodeName.StartsWith(search))
            .Select(x => new RefusalReasonCodeReferenceDto(
                Id: x.RefusalReasonCodeId,
                Name: x.RefusalReasonCodeName))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
