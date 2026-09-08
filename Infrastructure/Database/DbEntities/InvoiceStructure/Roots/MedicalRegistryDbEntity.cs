using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;
using Infrastructure.Database.DbEntities.InvoiceStructure.Headings;

namespace Infrastructure.Database.DbEntities.InvoiceStructure.Roots;

public sealed class MedicalRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short Status { get; set; }

    public MedicalRegistryHeadingDbEntity MedicalRegistryHeading { get; set; } = null!;
    public InvoiceDbEntity Invoice { get; set; } = null!;
    public IReadOnlyCollection<MedicalRecordDbEntity> MedicalRecords { get; set; } = [];
}