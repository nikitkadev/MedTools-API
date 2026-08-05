namespace Core.Dtos.RControl.Categories.Oncology;

public record InjectionsQueryResult(
    List<InjDateDto> InjDates,
    List<InjectionDto> Injs);

public class InjDateDto
{
    public int Uid { get; set; }
    public DateTime DateInj { get; set; }
}

public class InjectionDto
{
    public int Uid { get; set; }
    public DateTime DateInj { get; set; }
    public decimal? KvInj { get; set; }
    public decimal? KizInj { get; set; }
    public decimal? SInj { get; set; }
    public decimal? SvInj { get; set; }
    public decimal? SizInj { get; set; }
    public bool? RedInj { get; set; }
}