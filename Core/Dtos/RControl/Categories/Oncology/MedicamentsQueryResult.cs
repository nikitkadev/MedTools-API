namespace Core.Dtos.RControl.Categories.Oncology;

public record MedicamentsQueryResult(List<MedicamentDto> Medicaments);

public class MedicamentDto
{
    public int Uid { get; set; }
    public string Regnum { get; set; } = string.Empty;
    public string? RegnumDop { get; set; }
    public string? CodeSh { get; set; }
}