namespace Core.Dtos.RControl.Categories.Oncology;

public record ConsultationsQueryResult(
    List<ConsultationDto> Consultations);

public class ConsultationDto
{
    public byte PrCons { get; set; }
    public DateTime? DtCons { get; set; }
}