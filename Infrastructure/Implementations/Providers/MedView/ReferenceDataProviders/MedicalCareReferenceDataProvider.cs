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
    public async Task<IReadOnlyCollection<MedicalCareProfileReferenceDto>> GetMedicalCareProfileReferencesAsync(CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb: TargetDbType.MEDSPR18);

        return await dbContext
            .Set<MedicalCareProfileDbEntity>()
            .Select(x => new MedicalCareProfileReferenceDto(
                ProfileId: x.ProfileId,
                ProfileName: x.ProfileName))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}