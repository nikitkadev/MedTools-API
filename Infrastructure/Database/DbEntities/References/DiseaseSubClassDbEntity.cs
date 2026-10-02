namespace Infrastructure.Database.DbEntities.References;

public sealed class DiseaseSubClassDbEntity
{
    public int Uid { get; set; }

    public string? SubClassName { get; set; }
    public string? StartingDiseasePrefix { get; set; }
    public string? EndingDiseasePrefix { get; set; }
}
