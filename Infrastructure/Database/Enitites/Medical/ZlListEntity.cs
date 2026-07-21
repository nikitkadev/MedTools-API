namespace Infrastructure.Database.Enitites.Medical;

public class ZlListEntity
{
    public int Uid { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public string? Uploader { get; set; }
    public short Status { get; set; } = -1;

    public ZglvEntity? Zglv { get; set; }
    public SchetEntity? Schet { get; set; }
    public List<ZapEntity> Zaps { get; set; } = [];
}
