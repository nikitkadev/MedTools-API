namespace Core.Dtos.RControl.Categories.Oncology;

public record OncSluchQueryResult(
    OncSluchDto OncSluch);

public class OncSluchDto
{
    public int Uid { get; set; }
    public int SluchUid { get; set; }
    public byte? Ds1T { get; set; }
    public int? Stad { get; set; }
    public int? OnkT { get; set; }
    public int? OnkN { get; set; }
    public int? OnkM { get; set; }
    public byte? Mtstz { get; set; }
    public float? Sod { get; set; }
    public byte? KFr { get; set; }
    public float? Wei { get; set; }
    public int? Hei { get; set; }
    public float? Bsa { get; set; }
}
