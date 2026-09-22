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
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TherapyRegimenReferenceDto>> GetTherapyRegimenReferencesAsync(
        CancellationToken cancellationToken = default);
}