using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IMedicalServiceReferenceDataProvider
{
    Task<IReadOnlyCollection<OncologyServiceTypeReferenceDto>> GetOncologyServiceTypeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<SurgicalTreatmentTypeReferenceDto>> GetSurgicalTreatmentTypeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<RadioTherapyTypeReferenceDto>> GetRadioTherapyTypeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DrugTherapyLineReferenceDto>> GetDrugTherapyLineReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DrugTherapyCycleReferenceDto>> GetDrugTherapyCycleReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DrugIdentifierReferenceDto>> GetDrugIdentifierReferencesAsync(
        string search,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TherapyRegimenReferenceDto>> GetTherapyRegimenReferencesAsync(
        string search,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<MedicalServiceReferenceDto>> GetMedicalServiceReferencesAsync(
        string search,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ReferralTypeReferenceDto>> GetReferralTypeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<InterruptedCasePaymentReasonReferenceDto>> GetInterruptedCasePaymentReasonReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ProvidedServiceReferenceDto>> GetProvidedServiceReferencesAsync(
        string search,
        CancellationToken cancellationToken = default);
}