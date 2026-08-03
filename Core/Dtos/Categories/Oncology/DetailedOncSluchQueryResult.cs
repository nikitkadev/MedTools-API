namespace Core.Dtos.Categories.Oncology;

public record DetailedOncSluchQueryResult(
    List<OncologyServiceDto> Services,
    List<DiagDto> Diags,
    List<OncologyContraindicationDto> Contraindications);

public class OncologyServiceDto
{
    public int Uid { get; set; }
    public byte UslTip { get; set; }
    public byte? HirTip { get; set; }
    public byte? LekTipL { get; set; }
    public byte? LekTipV { get; set; }
    public byte? PPTR { get; set; }
    public byte? LuchTip { get; set; }
}

public class DiagDto
{
    public DateTime? DiagDate { get; set; }
    public byte? DiagTip { get; set; }
    public int? DiagCode { get; set; }
    public int? DiagRslt { get; set; }
    public byte? RecRslt { get; set; }
}

public class OncologyContraindicationDto
{
    public byte Prot { get; set; }
    public DateTime DProt { get; set; }
}
