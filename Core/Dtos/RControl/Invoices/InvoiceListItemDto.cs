namespace Core.Dtos.RControl.Invoices;

public sealed record InvoiceListItemDto(
    int InvoiceUid,
    string Number,
    DateTime BillingDate,
    decimal Amount,
    int MedicalCasesCount,
    short Status);
