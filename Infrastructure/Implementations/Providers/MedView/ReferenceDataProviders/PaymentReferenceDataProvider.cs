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
}
