namespace Infrastructure.Database.DbEntities.InvoiceStructure;

public sealed class ClassificationCriterionDbEntity
{
    public int Uid { get; set; }
    public int ClinicalGroupUid { get; set; }

    public string? ClassificationCriterionName { get; set; }
}
