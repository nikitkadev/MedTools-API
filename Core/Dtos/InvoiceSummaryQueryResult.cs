namespace Core.Dtos;

public record InvoiceSummaryQueryResult(
    string Filename,
    int SchetUid,
    DateTime UploadDate,
    decimal Summav,
    decimal Summap,
    decimal SankMek,
    decimal SankMee,
    decimal SankEkmp,
    decimal SmoSummap,
    decimal SmoSankMek,
    decimal SmoSankMee,
    decimal SmoSankEkmp);
