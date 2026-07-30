namespace Core.Dtos.Categories.ProvidedServices;

public record ProvidedServicesQueryResult(
    List<ProvidedServiceDto> ProvidedServices);

public class ProvidedServiceDto
{
    public int Uid { get; set; }
    public string CodeUsl { get; set; } = string.Empty;
    public string? VidVme { get; set; }
    public int Profil { get; set; }
    public int Prvs { get; set; }
    public byte Det { get; set; }
    public DateTime DateIn { get; set; }
    public DateTime DateOut { get; set; }
    public string Ds { get; set; } = string.Empty;
    public decimal KolUsl { get; set; }
    public decimal? Tarif { get; set; }
    public decimal SumvUsl { get; set; }
    public string? Comentu { get; set; }
}
