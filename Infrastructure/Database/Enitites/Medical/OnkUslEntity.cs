namespace Infrastructure.Database.Enitites.Medical;

public class OnkUslEntity
{
    public int Uid { get; set; }
    public int OnkSluchUid { get; set; }
    public byte UslTip { get; set; }
    public byte? HirTip { get; set; }
    public byte? LekTipL { get; set; }
    public byte? LekTipV { get; set; }
    public List<LekPrEntity>? LekPrs { get; set; }
    public byte? PPTR { get; set; }
    public byte? LuchTip { get; set; }
}