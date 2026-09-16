using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;

namespace Infrastructure.Implementations.Providers.MedView.ReferenceDataProviders;

public sealed class MedicalOrganizationReferenceDataProvider(
    DbContextFactory dbContextFactory) : IMedicalOrganizationReferenceDataProvider
{
    public async Task<IReadOnlyCollection<MedicalOrganziationReferenceDto>> GetMedicalOrganizationsByKeysAsync(
        IReadOnlyCollection<string> keys, 
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<MedicalOrganizationDbEntity>()
            .Where(x => keys.Contains(x.MedicalOrganizationCode) && x.MedicalOrganizationCode != null && x.MedicalOrganizationShortname != null)
            .Select(x => new MedicalOrganziationReferenceDto(
                Code: x.MedicalOrganizationCode!,
                Name: x.MedicalOrganizationShortname!))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<InsuranceReferenceDto>> GetInsurancesByKeysAsync(
        IReadOnlyCollection<string> keys, 
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<InsuranceDbEntity>()
            .Where(x => keys.Contains(x.InsuranceCode))
            .Select(x => new InsuranceReferenceDto(
                Code: x.InsuranceCode, 
                Name: x.InsuranceShortname))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<VisitPlaceReferenceDto>> GetVisitPlaceReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<VisitPlaceDbEntity>()
            .Select(x => new VisitPlaceReferenceDto(
                Id: x.VisitPlaceId,
                Name: x.VisitPlaceName))
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<IReadOnlyCollection<VisitPurposeReferenceDto>> GetVisitPurposeReferencesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);

        var result = await dbContext
            .Set<VisitPurposeDbEntity>()
            .Where(x => x.VisitPurposeName != null)
            .Select(x => new VisitPurposeReferenceDto(
                Id: x.VisitPurposeId,
                Name: x.VisitPurposeName!))
            .Distinct()
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
