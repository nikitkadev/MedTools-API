namespace Core.Interfaces.Providers.MedView.AvailableKeysProviders;

public interface IAvaliableKeysHelper
{
    Task<IReadOnlyCollection<int>> GetAvailableDiseaseStageKeysAsync(
        IReadOnlyCollection<string> names, 
        CancellationToken cancellationToken = default);
}
