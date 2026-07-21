namespace Core.Dtos;

public record InvoicesShortlyQueryResult(
    List<InvoicesShortlyDto> InvoicesShortlies,
    int TotalRecords);

public record InvoicesShortlyDto(
    string InvoiceNumber,
    DateTime InvoiceDate,
    decimal InvoiceAmount,
    int Cases,
    short Status);
