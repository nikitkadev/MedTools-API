namespace Infrastructure.Database.DbEntities.References;

public sealed class DiseaseCharacterDbEntity
{
    public int Uid { get; set; } 

    public byte CharacterId { get; set; }
    public string? CharacterName { get; set; } 
}
