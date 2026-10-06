namespace Infrastructure.Database.DbEntities.References;

public sealed class ProvidedServiceDbEntity
{
    public int Uid { get; set; }

    public string? ProvidedServiceId { get; set; }
    public string? ProvidedServiceName { get; set; }
}
