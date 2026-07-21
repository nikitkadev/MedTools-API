namespace Infrastructure.Database.Enitites.Medical;

public class KsgKpgEntity
{
    public int Uid { get; set; }
    public int SluchUid { get; set; }
    public string NKsg { get; set; } = string.Empty;
    public int VerKsg { get; set; }
    public byte KsgPg { get; set; }
    public string? NKpg { get; set; }
    public decimal KoefZ { get; set; }
    public decimal KoefUp { get; set; }
    public decimal Bztsz { get; set; }
    public decimal KoefD { get; set; }
    public decimal KoefU { get; set; }
    public decimal? KZp { get; set; }
    public byte SlK { get; set;  }
    public decimal? ItSl { get; set; }
    public string PrPr { get; set; } = string.Empty;
    public decimal? KoefPr { get; set; }
    public string? Ksg { get; set; }


    public List<string>? Crits { get; set; }
    public List<SlKoefEntity>? SlKoefs { get; set; }
    public List<CritEntity> CritEntities { get; set; } = [];
}