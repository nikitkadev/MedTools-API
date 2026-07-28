namespace Core.Dtos;

public record CategoryCasesQueryResult(
    CaseCategoryDto Case,
    FinishedCaseCategoryDto FinishedCase);

public record CaseCategoryDto(
    int Profil,
    string? Lpu1,
    long? Podr,
    int Prvs,
    short Det,
    string? PCel,
    int? ProfilK,
    string NHistory,
    short? PPer,
    byte? Reab,
    DateTime Date1,
    DateTime Date2,
    decimal? EdCol,
    int? KD,
    string? LpuLevel,
    string? Ds0,
    byte? DsOnk,
    string Iddokt,
    decimal? Wei,
    string Ds1,
    byte? CZab,
    string? Comentsl);

public record FinishedCaseCategoryDto(
    string Lpu,
    string? NprMo,
    DateTime? NprDate,
    int UslOk,
    int VidPom,
    short Idsp,
    byte ForPom,
    DateTime DateZ1,
    DateTime DateZ2,
    int? KdZ,
    int Rslt,
    byte? VbP,
    int? RsltD,
    byte? POtk,
    byte? Vbr,
    int Ishod);
