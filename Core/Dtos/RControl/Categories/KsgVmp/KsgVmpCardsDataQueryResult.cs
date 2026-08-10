namespace Core.Dtos.RControl.Categories.KsgVmp;

public record KsgVmpCardsDataQueryResult(
    KsgKpgDto? KsgKpg,
    VmpDto? Vmp);

public class KsgKpgDto
{
    public int Uid { get; set; }
    public string NKsg { get; set; } = string.Empty;
    public int VerKsg { get; set; }
    public byte KsgPg { get; set; }
    public string? NKpg { get; set; }
    public float KoefZ { get; set; }
    public float KoefUp { get; set; }
    public decimal Bztsz { get; set; }
    public float KoefD { get; set; }
    public float KoefU { get; set; }
    public byte SlK { get; set; }
    public float? ItSl { get; set; }
    public string? Ksg { get; set; }
}

public class VmpDto
{
    public string? VidHmp { get; set; }
    public string? MetodHmp { get; set; }
    public DateTime? TalD { get; set; }
    public string? TalNum { get; set; }
    public DateTime? TalP { get; set; }

}