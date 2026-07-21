namespace Infrastructure.Database.Enitites.Medical;

public class MedDevEntity
{
    public int Uid { get; set; }
    public int UslUid { get; set; }
    public DateTime DateMed { get; set; }
    public int CodeMeddev { get; set; }
    public string NumberSer { get; set; } = string.Empty;
}
