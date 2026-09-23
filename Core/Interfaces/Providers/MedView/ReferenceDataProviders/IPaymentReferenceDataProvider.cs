using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IPaymentReferenceDataProvider
{
    Task<IReadOnlyCollection<PaymentMethodReferenceDto>> GetPaymentMethodReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ClinicalGroupReferenceDto>> GetClinicalGroupReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ComplexityCoefficientReferenceDto>> GetComplexityCoefficientReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ControlTypeCodeReferenceDto>> GetControlTypeCodeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<RefusalReasonCodeReferenceDto>> GetRefusalReasonCodeReferencesAsync(
        CancellationToken cancellationToken = default);
}
