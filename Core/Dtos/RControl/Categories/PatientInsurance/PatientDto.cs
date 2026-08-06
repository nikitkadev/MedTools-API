namespace Core.Dtos.RControl.Categories.PatientInsurance;

public sealed record PatientDto(
    string PatientLastName,
    string PatientFirstName,
    string PatientMiddleName,
    DateTime PatientBirthday,
    string PatientSex,
    string DocumentTypeName,
    string? DocumentTypeCode,
    string? DocumentSeries,
    string? DocumentNumber,
    DateTime? DocumentIssueDate,
    string? IssuedBy,
    string? PatientRepresentativeLastName,
    string? PatientRepresentativeFirstName,
    string? PatientRepresentativeMiddleName,
    DateTime? PatientRepresentativeBirthday,
    string? PatientRepresentativeSex);
