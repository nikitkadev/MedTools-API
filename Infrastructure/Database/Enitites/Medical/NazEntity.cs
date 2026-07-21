namespace Infrastructure.Database.Enitites.Medical;

public class NazEntity
{
    public int Uid { get; set; }
    public int SluchUId { get; set; }
    public int NazN { get; set; }
    public byte NazR { get; set; }
    public byte? NazV { get; set; }
    public string? NazUsl { get; set; }
    public DateTime? NaprDate { get; set; }
    public string? NaprMo { get; set; }
    public int? NazPmp { get; set; }
    public string? NazPk { get; set; }
}