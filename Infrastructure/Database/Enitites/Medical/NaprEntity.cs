namespace Infrastructure.Database.Enitites.Medical;

public class NaprEntity
{
    public int Uid { get; set; }
    public int SluchUId { get; set; }
    public DateTime NaprDate { get; set; }
    public string? NaprMo { get; set; }
    public byte NaprV { get; set; }
    public byte? MetIssl { get; set; }
    public string? NaprUsl { get; set; }
}