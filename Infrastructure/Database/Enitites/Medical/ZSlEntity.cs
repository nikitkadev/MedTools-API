namespace Infrastructure.Database.Enitites.Medical;

public class ZSlEntity
{
    public int Uid { get; set; }
    public int ZapUid { get; set; }
    public long Idcase { get; set; }
    public int UslOk { get; set; }
    public int VidPom { get; set; }
    public byte ForPom { get; set; }
    public string? NprMo { get; set; }
    public DateTime? NprDate { get; set; }
    public string? NprNum { get; set; }
    public string Lpu { get; set; } = string.Empty;
    public byte? Vbr { get; set; }
    public byte? EveningTime { get; set; }
    public DateTime DateZ1 { get; set; }
    public DateTime DateZ2 { get; set; }
    public byte? POtk { get; set; }
    public int? RsltD { get; set; }
    public int? KdZ { get; set; }
    public int? VnovM { get; set; }
    public int Rslt { get; set; }
    public int Ishod { get; set; }
    public byte? OsSluch { get; set; }
    public byte? VbP { get; set; }
    public short Idsp { get; set; }
    public decimal SumV { get; set; }
    public byte? Oplata { get; set; } 
    public decimal? Sump { get; set; } 
    public decimal? SmoSump { get; set; } 
    public decimal? SankIt { get; set; }
    public decimal? SmoSankIt { get; set; }

    public List<SlEntity>? Sls { get; set; }
}