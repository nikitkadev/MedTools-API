namespace Infrastructure.Database.DbEntities.References;

public sealed class PaymentMethodDbEntity
{
    public int Uid { get; set; }

    public string PaymentMethodName { get; set; } = string.Empty;
}
