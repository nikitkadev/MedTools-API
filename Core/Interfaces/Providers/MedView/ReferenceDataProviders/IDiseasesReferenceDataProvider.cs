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
}
