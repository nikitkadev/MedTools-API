namespace Core.Dtos;

public record MedOrganizationsQueryResult(
    List<MedOrganizationDto> MedOrganizations);

public record MedOrganizationDto(
    string Name,
    string Code);