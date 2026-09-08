namespace Infrastructure.Database.DbEntities.InvoiceStructure.Roots;

public sealed class MedicalRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short Status { get; set; }
}
