namespace Core.Dtos;

public record InvoicesShortlyQueryResult(
    List<InvoiceShortlyDto> InvoicesShortlies,
    int TotalRecords);

public record InvoiceShortlyDto(
    string InvoiceNumber,
    DateTime InvoiceDate,
    decimal InvoiceAmount,
    int Cases,
    short Status);
