namespace Core.Dtos.RControl.Categories.DefectsSanks;

public record DefectsQueryResult(
    List<DefectDto> Defects,
    int TotalItems);

public class DefectDto
{
    public int Uid { get; set; }
    public short? Kod { get; set; }
    public string Comment { get; set; } = string.Empty;
}
