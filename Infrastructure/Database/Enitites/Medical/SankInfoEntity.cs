namespace Infrastructure.Database.Enitites.Medical;

public sealed class SankInfoEntity
{
    public int Uid { get; set; }
    public int ZlListUid { get; set; }
    public string? Filename { get; set; }
    public DateTime? UploadeDate { get; set; }
    public long? Code { get; set; }
    public string? CodeMo { get; set; }
    public int? Year { get; set; }
    public int? Month { get; set; }
    public string? NSchet { get; set; }
    public DateTime? DSchet { get; set; }
    public string? Plat { get; set; }
    public decimal? Summav { get; set; }
    public decimal? SmoSummap { get; set; }
    public decimal? SmoSankMek { get; set; }
    public decimal? SmoSankMee { get; set; }
    public decimal? SmoSankEkmp { get; set; }
    public int? SankYear { get; set; }
    public int? SankMonth { get; set; }

    public List<SankEntity> Sanks { get; set; } = [];
}