namespace Infrastructure.Database.Enitites.Medical;

public class ZapEntity
{
    public int Uid { get; set; }
    public int ZlListUid { get; set; }
    public int PacientUid { get; set; }
    public long NZap {  get; set; }
    public short PrNov { get; set; }

    public PacientEntity? Pacient { get; set; }
    public ZSlEntity? ZSl { get; set; }
}
