namespace Infrastructure.Database.Enitites.Medical;

public class PersListEntity
{
    public int Uid { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public string? Uploader { get; set; }
    public short? Status { get; set; } = -1;

    public PZglvEntity? PZglv { get; set; }
    public List<PersEntity>? Pers { get; set; } = [];
}
