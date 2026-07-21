namespace Infrastructure.Database.Enitites.Medical;

public class PacientEntity
{
    public int Uid { get; set; }
    public string IdPac { get; set; } = string.Empty;
    public byte Vpolis { get; set; }
    public string? Spolis { get; set; }
    public string Npolis { get; set; } = string.Empty;
    public string? Enp { get; set; }
    public string? StOkato { get; set; }
    public string? Smo { get; set; }
    public string? SmoOgrn { get; set; }
    public string? SmoOk { get; set; }
    public string? SmoNam { get; set; }
    public byte? Inv { get; set; }
    public byte? Mse { get; set; }
    public string Novor { get; set; } = string.Empty;
    public int? VnovD{ get; set; }
    public string Soc { get; set;  } = string.Empty;
    public int? NextD { get; set; }
    public string? MoPr { get; set; }
    public string? VZ { get; set; }
}
