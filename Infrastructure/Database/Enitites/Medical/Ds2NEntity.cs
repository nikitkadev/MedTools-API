namespace Infrastructure.Database.Enitites.Medical;

public class Ds2NEntity
{
    public int Uid { get; set; }
    public int SluchUid { get; set; }
    public string Ds2 { get; set; } = string.Empty;
    public byte? Ds2PR { get; set; }
    public byte PRDs2N { get; set; }
}