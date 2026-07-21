namespace Infrastructure.Database.Enitites.Medical;

public class ZglvEntity
{
    public int Uid { get; set; }
    public int ZlListUid { get; set; }
    public string? Version { get; set; }
    public DateTime? Data { get; set; }
    public string? FileName { get; set; }
    public int? SdZ { get; set; }
}
