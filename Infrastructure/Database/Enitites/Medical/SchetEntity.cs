namespace Infrastructure.Database.Enitites.Medical;

public class SchetEntity
{
    public int Uid { get; set; }
    public int ZlListUid { get; set; }
    public long Code { get; set; }
    public string CodeMO { get; set; } = string.Empty;
    public int Year { get; set; }
    public byte Month { get; set; }
    public string Nschet { get; set; } = string.Empty;
    public DateTime Dschet { get; set; }
    public string? Plat { get; set; }
    public decimal Summav { get; set; }
    public string? Coments { get; set; }
    public decimal? Summap { get; set; } = 0m;
    public decimal? SankMek { get; set; } = 0m;
    public decimal? SankMee { get; set; } = 0m;
    public decimal? SankEkmp { get; set; } = 0m;
    public decimal? SmoSummap { get; set; } = 0m;
    public decimal? SmoSankMek { get; set; } = 0m;
    public decimal? SmoSankMee { get; set; } = 0m;
    public decimal? SmoSankEkmp { get; set; } = 0m;
    public string? Disp { get; set; }
}
