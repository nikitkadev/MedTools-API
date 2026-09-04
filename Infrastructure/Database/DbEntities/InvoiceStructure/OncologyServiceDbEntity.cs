namespace Infrastructure.Database.DbEntities.InvoiceStructure;

public sealed class OncologyServiceDbEntity
{
    public int Uid { get; set; }
    public int OncologyCaseUid { get; set; }

    public byte ServiceTypeCode { get; set; }
    public byte? SurgicalTreatmentTypeCode { get; set; }
    public byte? DrugTherapyLineCode { get; set; }
    public byte? DrugTherapyCycleCode { get; set; }
    public bool? IsAntiemeticProphylaxis { get; set; }
    public byte? RadioTherapyTypeCode { get; set; }
}
