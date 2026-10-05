namespace Core.Interfaces.Providers.MedView;

public interface IDiseasesDataProvider
{
    Task<IReadOnlyCollection<string>> GetDiseasesByClassUidsAsync(
        IReadOnlyCollection<int> uids,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<string>> GetDiseasesBySubClassUidsAsync(
        IReadOnlyCollection<int> uids,
        CancellationToken cancellationToken);
}
