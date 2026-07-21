namespace Infrastructure.Database.Enitites.Medical;

public class UslEntity
{
    public int Uid { get; set; }
    public int SluchUid { get; set; }
    public string Idserv { get; set; } = string.Empty;
    public string Lpu { get; set; } = string.Empty;
    public string? Lpu1 { get; set; }
    public long? Podr { get; set; }
    public int Profil { get; set; }
    public string? VidVme { get; set; }
    public byte Det { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public byte? POtk { get; set; }
    public string DS { get; set; } = string.Empty;
    public string CodeUsl { get; set; } = string.Empty;
    public decimal KolUsl { get; set; }
    public decimal? Tarif { get; set; }
    public decimal SumvUsl { get; set; }
    public int PRVS { get; set; }
    public string CodeMd { get; set; } = string.Empty;
    public short? NPL { get; set; }
    public string? Comentu { get; set; }
    public string? VolumeCode { get; set; }

    public List<MedDevEntity>? MedDevs { get; set; }
    public List<MrUslNEntity>? MrUslNs { get; set; }
    public UslDopParamEntity? UslDopParams { get; set; }
}
