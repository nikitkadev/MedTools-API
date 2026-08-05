using Core.Dtos.Lookups;

namespace Application.Queries.RContol.Lookups.GetMedicalOrganizationsQuery;

public sealed record GetMedicalOrganizationsResult(
    IReadOnlyCollection<MedicalOrganizationDto> MedicalOrganizations);
