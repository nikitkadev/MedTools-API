using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Internal;

internal sealed class CompletedCaseSearchRow
{
    public required CompletedCaseDbEntity CompletedCase { get; init; }
    public required PersonDbEntity Person { get; init; }
}
