namespace Infrastructure.Database.DbEntities.References;

public sealed class DivisionDbEntity
{
    public int Uid { get; set; }

    public string? DivisionId { get; set; }
    public string? DivisionName { get; set; } = string.Empty;
}
