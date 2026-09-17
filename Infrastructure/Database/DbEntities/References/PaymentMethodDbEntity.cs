namespace Infrastructure.Database.DbEntities.References;

public sealed class PaymentMethodDbEntity
{
    public short Uid { get; set; }

    public string PaymentMethodName { get; set; } = string.Empty;
}
