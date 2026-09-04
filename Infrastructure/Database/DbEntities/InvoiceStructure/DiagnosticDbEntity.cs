namespace Infrastructure.Database.DbEntities.InvoiceStructure;

public sealed class DiagnosticDbEntity
{
    public int Uid { get; set; }
    public int OncologyCaseUid { get; set; }

    public byte? DiagnosticType { get; set; }
    public int? DiagnosticCode { get; set; }
    public int? DiagnosticResultCode { get; set; }
    public DateTime? SpecimenCollectionDate { get; set; } 
    public byte? IsResultReceived { get; set; }

}