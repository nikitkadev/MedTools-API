namespace Infrastructure.Database.DbEntities.InvoiceStructure;

public sealed class ConsultationDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public byte ConsultationPurposeCode { get; set; }
    public DateTime? ConsultationDate { get; set; }
}
