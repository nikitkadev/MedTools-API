namespace Infrastructure.Database.Enitites.Medical;

public class LekPrEntity
{
    public int Uid { get; set; }
    public int OnkUslUid { get; set; }
    public string Regnum { get; set; } = string.Empty;
    public string? RegnumDop { get; set; }
    public string? CodeSh { get; set; }

    public List<DateTime> DateInjs { get; set; } = [];
    public List<InjEntity>? Injs { get; set; }
    public List<DateInjEntity> DateInjEntities { get; set; } = [];
}
