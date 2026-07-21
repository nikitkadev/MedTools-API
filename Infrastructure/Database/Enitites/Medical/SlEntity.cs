namespace Infrastructure.Database.Enitites.Medical;

public class SlEntity
{
    public int Uid { get; set; }
    public int ZSlUid { get; set; }
    public string SlId { get; set; } = string.Empty;
    public string? VidHmp { get; set; }
    public int? MetodHmp { get; set; }
    public string? Lpu1 { get; set; }
    public long? Podr { get; set; }
    public int Profil { get; set; }
    public int? ProfilK { get; set; }
    public short Det { get; set; }
    public DateTime? TalD { get; set; }
    public string? TalNum { get; set; }
    public DateTime? TalP { get; set; }
    public string? PCel { get; set; }
    public string? Mop { get; set; }
    public string NHistory { get; set; } = string.Empty;
    public short? PPer { get; set; }
    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
    public int? KD { get; set; }
    public decimal? Wei { get; set; }
    public string? Ds0 { get; set; }
    public string Ds1 { get; set; } = string.Empty;
    public byte? Ds1_Pr { get; set; }
    public byte? CZab { get; set; }
    public byte? DsOnk { get; set; }
    public byte? PrDN { get; set; }
    public byte? ProfM { get; set; }
    public byte? Dn { get; set; }
    public string? CodeMes1 { get; set; }
    public string? CodeMes2 { get; set; }
    public byte? Reab { get; set; }
    public int Prvs { get; set; }
    public string VersSpec { get; set; } = string.Empty;
    public string Iddokt { get; set; } = string.Empty;
    public decimal? EdCol { get; set; }
    public decimal? Tarif { get; set; }
    public decimal SumM { get; set; }
    public decimal? SmoSump { get; set; }
    public string? Comentsl { get; set; }
    public decimal? SankMek { get; set; }
    public decimal? SankMee { get; set; }
    public decimal? SankEkmp { get; set; }
    public string? LpuLevel { get; set; }

    public OnkSlEntity? OnkSl { get; set; }
    public KsgKpgEntity? KsgKpg { get; set; }
    public List<NaprEntity>? Naprs { get; set; }
    public List<ConsEntity>? Cons { get; set; }
    public List<Ds2NEntity>? Ds2Ns { get; set; }
    public List<NazEntity>? Nazs { get; set; }
    public List<SlLekPrEntity>? SluchLekPrs { get; set; }
    public List<SankEntity>? Sanks { get; set; }
    public List<UslEntity>? Usls { get; set; }
    public List<string>? Ds2 { get; set; }
    public List<string>? Ds3 { get; set; }
    public List<Ds2Entity> Ds2s { get; set; } = [];
    public List<Ds3Entity> Ds3s { get; set; } = [];
}
