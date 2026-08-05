namespace Core.Dtos.RControl.Categories.NazNapr;

public record NazNaprQueryResult(
    List<PurposeDto> Purposes,
    List<DirectionDto> Directions);

public class PurposeDto
{
    public int Uid { get; set; }
    public int NazN { get; set; }
    public byte NazR { get; set; }
    public byte? NazV { get; set; }
    public string? NazUsl { get; set; }
    public DateTime? NaprDate { get; set; }
    public string? NaprMo { get; set; }
    public int? NazPmp { get; set; }
    public string? NazPk { get; set; }
}

public class DirectionDto
{
    public int Uid { get; set; }
    public DateTime NaprDate { get; set; }
    public string? NaprMo { get; set; }
    public byte NaprV { get; set; }
    public byte? MetIssl { get; set; }
    public string? NaprUsl { get; set; }
}