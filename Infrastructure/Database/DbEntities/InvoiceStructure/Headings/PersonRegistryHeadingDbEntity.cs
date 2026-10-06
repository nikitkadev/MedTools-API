using Infrastructure.Database.DbEntities.InvoiceStructure.Roots;

namespace Infrastructure.Database.DbEntities.InvoiceStructure.Headings;

public sealed class PersonRegistryHeadingDbEntity
{
    public int PersonRegistryUid { get; set; }

    public string? Version { get; set; }
    public DateTime? Date { get; set; }
    public string? PersonRegistryFilename { get; set; }
    public string? MedicalRegistryFilename { get; set; }

    public PersonRegistryDbEntity PersonRegistry { get; set; } = null!;
}
