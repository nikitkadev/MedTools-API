using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IPaymentReferenceDataProvider
{
    Task<IReadOnlyCollection<PaymentMethodReferenceDto>> GetPaymentMethodReferencesAsync(
        CancellationToken cancellationToken = default);
}
