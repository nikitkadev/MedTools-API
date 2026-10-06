namespace Infrastructure.Database.DbEntities.References;

public sealed class BedProfileDbEntity
{
    public int Uid { get; set; }

    public string BedProfileId { get; set; } = string.Empty;
    public string BedProfileName { get; set; } = string.Empty;
}
