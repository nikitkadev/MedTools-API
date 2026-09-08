namespace Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

public sealed class OncologyCaseDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public byte? ReferralReasonCode { get; set; }
    public int? Stage { get; set; }
    public int? TumorValue { get; set; }
    public int? NodusValue { get; set; }
    public int? MetastasisValue { get; set; }
    public byte? IsMetastasisDetected { get; set; }
    public float? TotalFocusDose { get; set; }
    public byte? RadiationFractionsCount { get; set; }
    public float? Weight { get; set; }
    public int? Height { get; set; }
    public float? BodySurfaceArea { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;
    public IReadOnlyCollection<OncologyServiceDbEntity> OncologyServices { get; set; } = [];
    public IReadOnlyCollection<DiagnosticDbEntity> Diagnostics { get; set; } = [];
    public IReadOnlyCollection<ContraindicationDbEntity> Contraindications { get; set; } = [];
}