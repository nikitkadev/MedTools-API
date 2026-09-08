using Infrastructure.Database.DbEntities.InvoiceStructure.Roots;

namespace Infrastructure.Database.DbEntities.InvoiceStructure.Headings;

public sealed class MedicalRegistryHeadingDbEntity
{
    public int MedicalRegistryUid { get; set; }

    public string? Version { get; set; }
    public DateTime? Date { get; set; }
    public string? Filename { get; set; }
    public int? TotalRecordCount { get; set; }
}
