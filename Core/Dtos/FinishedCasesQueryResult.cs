namespace Core.Dtos;

public record FinishedCasesQueryResult(
    List<FinishedCasesDto> FinisedCases,
    int TotalRecords);

public record FinishedCasesDto(
    int PacientUid,
    int PersUid,
    int ZSlUid,
    long PositionNumber,
    long RecordNumber,
    string Surname,
    string Name,
    string Patronymic,
    int UslOk,
    string? SPolis,
    string NPolis,
    decimal Sumv,
    decimal? Sump,
    decimal? SmoSump);
