namespace Core.Dtos;

public record CasesQueryResult(
    List<CaseDto> Cases);

public record CaseDto(
    int Uid,
    int? Profil,
    short Det,
    int Prvs,
    DateTime StartingAt,
    DateTime EndingAt,
    string Ds1,
    decimal? EdCol,
    decimal? Tarif,
    decimal SumM,
    decimal? Sump,
    decimal? SmoSump);
