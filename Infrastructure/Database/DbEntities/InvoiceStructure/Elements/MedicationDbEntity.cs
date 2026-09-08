namespace Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

public sealed class MedicationDbEntity
{
    public int Uid { get; set; }
    public int OncologyServiceUid { get; set; }

    public string DrugIdentifier { get; set; } = string.Empty;
    public string? DrugExtendedIdentifier { get; set; }
    public string? TherapyRegimenCode { get; set; }

    public OncologyServiceDbEntity OncologyService { get; set; } = null!;
    public IReadOnlyCollection<InjectionDateDbEntity> InjectionDates { get; set; } = [];
    public IReadOnlyCollection<InjectionDbEntity> Injections { get; set; } = [];
}
