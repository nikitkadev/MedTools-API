namespace Core.Dtos;

public record PatientSmoQueryResult(
    PatientDto Patient,
    SmoDto SMO);

public record PatientDto(
    string Surname,
    string Name,
    string Patronymic,
    byte Sex,
    DateTime Birthday,
    string? RepresentativeSurname,
    string? RepresentativeName,
    string? RepresentativePatronymic,
    byte? RepresentativeSex,
    DateTime? RepresentativeBithday,
    string? DocumentType,
    string? DocumentSeries,
    string? DocumentNumber,
    DateTime? IssueDate,
    string? IssuedBy);

public record SmoDto(
    string? SmoCode,
    string? SmoOGRN,
    string? SmoOKATO,
    string? SmoName,
    string? PolisSeries,
    string PolisNumber,
    byte PolisType,
    string? Enp);