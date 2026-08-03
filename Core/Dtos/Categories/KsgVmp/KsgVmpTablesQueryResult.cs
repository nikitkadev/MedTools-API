namespace Core.Dtos.Categories.KsgVmp;

public record KsgVmpTablesQueryResult(
    List<CritDto> Crits,
    List<SlKoefDto> SlKoefs);

public class CritDto
{
    public int Uid { get; set; }
    public string Crit { get; set; } = string.Empty;
}

public class SlKoefDto
{
    public int Uid { get; set; }
    public string IdSl { get; set; } = string.Empty;
    public float ZSl { get; set; } 
}