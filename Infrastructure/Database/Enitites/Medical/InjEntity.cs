namespace Infrastructure.Database.Enitites.Medical;

public class InjEntity
{
    public int Uid { get; set; }
    public int LekPrUid { get; set; }
    public DateTime DateInj { get; set; }
    public decimal? KvInj { get; set; }
    public decimal? KizInj { get; set; }
    public decimal? SInj { get; set; }
    public decimal? SvInj { get; set; }
    public decimal? SizInj { get; set; }
    public bool? RedInj { get; set; }
}
