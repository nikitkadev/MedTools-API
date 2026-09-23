namespace Infrastructure.Database.DbEntities.References;

public sealed class HighTechCareMethodDbEntity
{
    public int Uid { get; set; }

    public string? HighTechCareMethodId { get; set; }
    public string HighTechCareMethodName { get; set; } = string.Empty;
}
