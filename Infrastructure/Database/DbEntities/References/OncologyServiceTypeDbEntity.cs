namespace Infrastructure.Database.DbEntities.References;

public sealed class OncologyServiceTypeDbEntity
{
    public int Uid { get; set; }

    public int ServiceId { get; set; }
    public string? ServiceName { get; set; }
}
