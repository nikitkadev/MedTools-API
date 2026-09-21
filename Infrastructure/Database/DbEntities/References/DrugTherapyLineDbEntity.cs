namespace Infrastructure.Database.DbEntities.References;

public sealed class DrugTherapyLineDbEntity
{
    public int Uid { get; set; } 

    public int DrugTherapyLineId { get; set; }
    public string? DrugTherapyLineName { get; set; }
}
