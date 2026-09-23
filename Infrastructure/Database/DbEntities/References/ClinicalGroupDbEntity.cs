namespace Infrastructure.Database.DbEntities.References;

public sealed class ClinicalGroupDbEntity
{
    public int Uid { get; set; }

    public string ClinicalGroupId { get; set; } = string.Empty;
    public string? ClinicalGroupName { get; set; }
}
