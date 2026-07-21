namespace Infrastructure.Database.Enitites.Medical;

public class SankEntity
{
    public int Uid { get; set; }
    public int SluchUid { get; set; }
    public int SankInfoUid { get; set; }
    public string SCode { get; set; } = string.Empty;
    public decimal SSum { get; set; }
    public string STip { get; set; } = string.Empty;
    public int SOsn { get; set; }
    public string? SCom { get; set; }
    public short SIst { get; set; }
    public decimal SEDCol { get; set; }
    public string? SKsg { get; set; }
    public string SNact { get; set; } = string.Empty;
    public DateTime SDact { get; set; }
    public string? SCodex { get; set; }

    public SankInfoEntity SankInfo { get; set; } = new();
}