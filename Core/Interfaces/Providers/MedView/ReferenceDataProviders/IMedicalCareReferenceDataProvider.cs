using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IMedicalCareReferenceDataProvider
{
    Task<IReadOnlyCollection<MedicalCareProfileReferenceDto>> GetMedicalCareProfileReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<BedProfileReferenceDto>> GetBedProfileReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<PhysicianSpecialtyReferenceDto>> GetPhysicianSpecialtyReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<CareConditionReferenceDto>> GetCareConditionReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<MedicalCareTypeReferenceDto>> GetMedicalCareTypeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<CareFormReferenceDto>> GetCareFormReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ScreeningResultReferenceDto>> GetScreeningResultReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<HospitalizationOutcomeReferenceDto>> GetHospitalizationOutcomeReferencesAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ReferralReasonReferenceDto>> GetReferralReasonReferencesAsync(
        CancellationToken cancellationToken = default);
}