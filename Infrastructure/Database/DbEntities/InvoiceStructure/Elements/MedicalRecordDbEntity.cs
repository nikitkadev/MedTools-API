namespace Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

public sealed class MedicalRecordDbEntity
{
    public int Uid { get; set; }
    public int MedicalRegistryUid { get; set; }
    public int PatientUid { get; set; }

    public long RecordSequenceNumber { get; set; }
    public byte IsRevisedRecord { get; set; }

}
