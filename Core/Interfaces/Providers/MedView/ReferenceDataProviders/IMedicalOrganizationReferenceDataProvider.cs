using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IMedicalOrganizationReferenceDataProvider
{
    Task<IReadOnlyCollection<InsuranceReferenceDto>> GetInsurancesByKeysAsync(
        IReadOnlyCollection<string> keys, 
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<MedicalOrganziationReferenceDto>> GetMedicalOrganizationsByKeysAsync(
        IReadOnlyCollection<string> keys,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<VisitPlaceReferenceDto>> GetVisitPlaceReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<VisitPurposeReferenceDto>> GetVisitPurposeReferencesAsync(
        CancellationToken cancellationToken = default);
}
