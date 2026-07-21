namespace Infrastructure.Database.Enitites.Medical;

public class MrUslNEntity
{
    public int Uid { get; set; }
    public int UslUid { get; set; }
    public int MrN { get; set; }
    public int PRVS { get; set; }
    public string CodeMd { get; set; } = string.Empty;
}