using Core.Common.Enums;
using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.AvailableOrganizationsProvider;

public interface IAvailableMedicalOrganizationsProvider
{
    Task<IReadOnlyCollection<InsuranceReferenceDto>> GetInsuranceAsync(
        TargetDbType targetDb, 
        CancellationToken cancellationToken = default); 
}
