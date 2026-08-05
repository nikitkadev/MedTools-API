namespace Core.Dtos.RControl.Categories.ProvidedServices;

public record MedDevsQueryResult(
    List<MedDevDto> MedDevs);

public class MedDevDto
{
    public int Uid { get; set; }
    public DateTime DateMed { get; set; }
    public int CodeMeddev { get; set; }
    public string NumberSer { get; set; } = string.Empty;
}
