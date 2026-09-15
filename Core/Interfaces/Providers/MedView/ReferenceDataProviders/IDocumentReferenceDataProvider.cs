using Core.Dtos.MedView.Reference;

namespace Core.Interfaces.Providers.MedView.ReferenceDataProviders;

public interface IDocumentReferenceDataProvider
{
    Task<IReadOnlyCollection<InsurancePolicyTypeReferenceDto>> GetInsurancePolicyTypesAsync(CancellationToken cancellationToken = default);
}
