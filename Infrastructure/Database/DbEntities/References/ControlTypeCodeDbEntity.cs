namespace Infrastructure.Database.DbEntities.References;

public sealed class ControlTypeCodeDbEntity
{
    public int Uid { get; set; }

    public string ControlTypeCodeId { get; set; } = string.Empty;
    public string? ControlTypeCodeName { get; set; } 
}
