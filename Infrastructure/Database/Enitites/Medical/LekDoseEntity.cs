namespace Infrastructure.Database.Enitites.Medical;

public class LekDoseEntity
{
    public int Uid { get; set; }
    public int SluchLekPrUid { get; set; }
    public string EdIzm { get; set; } = string.Empty;
    public decimal DoseInj { get; set; }
    public string MethodInj { get; set; } = string.Empty;
    public int ColInj { get; set; }
}