namespace Infrastructure.Database.Enitites.Medical;

public class SlLekPrEntity
{
    public int Uid { get; set; }
    public int SluchUid { get; set; }
    public DateTime DataInj { get; set; }
    public string CodeSh { get; set; } = string.Empty;
    public string? Regnum { get; set; }
    public string? CodMark { get; set; }

    public LekDoseEntity? LekDose { get; set; }
}
