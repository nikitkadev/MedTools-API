using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IDiseasesReferenceDataProvider
{
    Task<IReadOnlyCollection<DiseaseCharacterReferenceDto>> GetDiseaseCharacterReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DiseaseOutcomeReferenceDto>> GetDiseaseOutcomeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DiseaseStageReferenceDto>> GetDiseaseStageReferencesAsync(
        string search,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DiseaseReferenceDto>> GetDiseaseReferencesAsync(
        string search,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DiseaseClassReferenceDto>> GetDiseaseClassReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<DiseaseSubClassReferenceDto>> GetDiseaseSubClassReferencesAsync(
        CancellationToken cancellationToken = default);
}
