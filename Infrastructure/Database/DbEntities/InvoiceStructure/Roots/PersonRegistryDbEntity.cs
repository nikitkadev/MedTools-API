namespace Infrastructure.Database.DbEntities.InvoiceStructure.Roots;

public sealed class PersonRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short? Status { get; set; }
}
