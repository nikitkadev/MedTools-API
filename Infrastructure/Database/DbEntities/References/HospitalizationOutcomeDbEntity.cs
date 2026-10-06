namespace Infrastructure.Database.DbEntities.References;

public sealed class HospitalizationOutcomeDbEntity
{
    public int Uid { get; set; }

    public short HospitalizationOutcomeId { get; set; }
    public short CareConditionId { get; set; }
    public string HospitalizationOutcomeName { get; set; } = string.Empty;
}
