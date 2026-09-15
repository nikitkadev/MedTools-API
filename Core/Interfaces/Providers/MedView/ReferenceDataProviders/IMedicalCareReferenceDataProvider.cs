using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IMedicalCareReferenceDataProvider
{
    Task<IReadOnlyCollection<MedicalCareProfileReferenceDto>> GetMedicalCareProfileReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<BedProfileReferenceDto>> GetBedProfileReferencesAsync(
        CancellationToken cancellationToken = default);
}
