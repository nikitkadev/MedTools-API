namespace Core.Dtos.RControl.Workspace;

public sealed record InvoiceListItemDto(
    int InvoiceUid,
    string Number,
    DateTime BillingDate,
    decimal Amount,
    int MedicalCasesCount,
    short Status);
