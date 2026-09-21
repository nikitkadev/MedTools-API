namespace Infrastructure.Database.DbEntities.References;

public sealed class DrugTherapyCycleDbEntity
{
    public int Uid { get; set; }

    public int DrugTherapyCycleId { get; set; }
    public string? DrugTherapyCycleName { get; set; }
}
