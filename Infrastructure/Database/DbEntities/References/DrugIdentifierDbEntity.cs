namespace Infrastructure.Database.DbEntities.References;

public sealed class DrugIdentifierDbEntity
{
    public int Uid { get; set; }

    public string? DrugIdentifierId { get; set; }
    public string? DrugIdentifierName { get; set; }
}
