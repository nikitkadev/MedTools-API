namespace Infrastructure.Database.Enitites.Medical;

public class PersEntity
{
    public int Uid { get; set; }
    public int PersListUid { get; set; }
    public string IdPac { get; set; } = string.Empty;
    public string Fam { get; set; } = string.Empty;
    public string Im { get; set; } = string.Empty;
    public string Ot { get; set; } = string.Empty;
    public byte W { get; set; }
    public DateTime Dr { get; set; }
    public byte? Dost { get; set; }
    public string? Tel { get; set; }
    public string? FamP { get; set; }
    public string? ImP { get; set; }
    public string? OtP { get; set; }
    public byte? WP { get; set; }
    public DateTime? DrP { get; set; }
    public byte? DostP { get; set; }
    public string? MR { get; set; }
    public string? Doctype { get; set; }
    public string? Docser { get; set; }
    public string? Docnum { get; set; }
    public DateTime? DocDate { get; set; }
    public string? DocOrg { get; set; }
    public string? Snils { get; set; }
    public string? Okatog { get; set; }
    public string? Okatop { get; set; }
    public string? Comentp { get; set; }
}