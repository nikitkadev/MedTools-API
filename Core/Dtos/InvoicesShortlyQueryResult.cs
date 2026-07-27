namespace Core.Dtos;

public record InvoicesShortlyQueryResult(
    List<InvoiceShortlyDto> InvoicesShortlies,
    int TotalRecords,
    int CurrentPage);

public record InvoiceShortlyDto(
    int InvoiceUid,
    string InvoiceNumber,
    DateTime InvoiceDate,
    decimal InvoiceAmount,
    int Cases,
    short Status);
