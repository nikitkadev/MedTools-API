namespace Infrastructure.Database.DbEntities.References;

public sealed class SurgicalTreatmentTypeDbEntity
{
    public int Uid { get; set; }

    public int SurgicalTreatmentTypeId { get; set; }
    public string? SurgicalTreatmentTypeName { get; set; }
}
