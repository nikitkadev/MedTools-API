namespace Infrastructure.Database.DbEntities.References;

public sealed class ScreeningResultDbEntity
{
    public int Uid { get; set; }

    public string ScreeningResultId { get; set; } = string.Empty;
    public string? ScreeningResultName { get; set; }
}
