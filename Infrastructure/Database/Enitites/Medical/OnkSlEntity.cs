namespace Infrastructure.Database.Enitites.Medical;

public class OnkSlEntity
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
    
    public List<BDiagEntity>? BDiags { get; set; }
    public List<BProtEntity>? BProts { get; set; }
    public List<OnkUslEntity>? OnkUsls { get; set; }
}