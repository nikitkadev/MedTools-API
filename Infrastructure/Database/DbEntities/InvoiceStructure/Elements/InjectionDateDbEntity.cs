namespace Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

public sealed class InjectionDateDbEntity
{
    public int Uid { get; set; }
    public int MedicationUid { get; set; }

    public DateTime InjectionDate { get; set; }
}
