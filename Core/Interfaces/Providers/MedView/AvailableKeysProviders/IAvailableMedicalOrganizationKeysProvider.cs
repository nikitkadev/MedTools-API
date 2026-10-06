using Core.Common.Enums;

namespace Core.Interfaces.Providers.MedView.AvailableKeysProviders;

public interface IAvailableMedicalOrganizationKeysProvider
{
    Task<IReadOnlyCollection<string>> GetInsuranceOrganizationsKeysAsync(
        TargetDbType targetDb, 
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<string>> GetMedicalOrganizationsKeysAsync(
        TargetDbType targetDb,
        MedicalOrgsKeysFrom medicalOrgsKeysFrom,
        CancellationToken cancellationToken = default);
}
