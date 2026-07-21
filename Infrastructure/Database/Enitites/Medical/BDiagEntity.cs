namespace Infrastructure.Database.Enitites.Medical;

public class BDiagEntity
{
    public int Uid { get; set; }
    public int OnkSluchUid { get; set; }
    public DateTime? DiagDate { get; set; }
    public byte? DiagTip { get; set; }
    public int? DiagCode { get; set; }
    public int? DiagRslt { get; set; }
    public byte? RecRslt { get; set; }
}
