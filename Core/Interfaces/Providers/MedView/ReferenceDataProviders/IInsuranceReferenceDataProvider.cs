using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IInsuranceReferenceDataProvider
{
    Task<IReadOnlyCollection<InsuranceReferenceDto>> GetByKeysAsync(
        IReadOnlyCollection<string> keys, 
        CancellationToken cancellationToken = default);
}
