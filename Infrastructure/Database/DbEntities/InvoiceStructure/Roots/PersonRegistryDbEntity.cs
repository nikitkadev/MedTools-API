using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;
using Infrastructure.Database.DbEntities.InvoiceStructure.Headings;

namespace Infrastructure.Database.DbEntities.InvoiceStructure.Roots;

public sealed class PersonRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short? Status { get; set; }

    public PersonRegistryHeadingDbEntity PersonRegistryHeading { get; set; } = null!;
    public IReadOnlyCollection<PersonDbEntity> Persons { get; set; } = [];
}
