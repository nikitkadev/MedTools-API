namespace Core.Dtos.RControl.Categories.DefectsSanks;

public record SanksQueryResult(
    List<SankDto> Sanks);


public class SankDto
{
    public int Uid { get; set; }
    public string SCode { get; set; } = string.Empty;
    public decimal SSum { get; set; }
    public string STip { get; set; } = string.Empty;
    public int SOsn { get; set; }
    public decimal SEDCol { get; set; }
    public DateTime SDact { get; set; }
    public string SNact { get; set; } = string.Empty;
    public string? SCodex { get; set; }
    public string? SCom { get; set; }
    public string? Filename { get; set; }
    public int? Year { get; set; }
    public int? Month { get; set; }
    public DateTime? UploadeDate { get; set; }
}