using Core.Common.Enums;

namespace Core.Interfaces.Providers.MedView.AvailableKeysProviders;

public interface IAvailableMedicalOrganizationKeysProvider
{
    Task<IReadOnlyCollection<string>> GetInsuranceOrganizationsKeysAsync(
        TargetDbType targetDb, 
        CancellationToken cancellationToken = default); 
}
