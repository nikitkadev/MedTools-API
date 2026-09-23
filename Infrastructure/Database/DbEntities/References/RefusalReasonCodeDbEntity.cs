namespace Infrastructure.Database.DbEntities.References;

public sealed class RefusalReasonCodeDbEntity
{
    public int Uid { get; set; }

    public short RefusalReasonCodeId { get; set; }
    public string RefusalReasonCodeName { get; set; } = string.Empty;
}
