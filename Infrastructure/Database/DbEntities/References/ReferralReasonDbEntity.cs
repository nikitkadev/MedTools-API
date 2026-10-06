namespace Infrastructure.Database.DbEntities.References;

public sealed class ReferralReasonDbEntity
{
    public int Uid { get; set; }

    public int ReferralReasonId { get; set; }
    public string? ReferralReasonName { get; set; }
}
