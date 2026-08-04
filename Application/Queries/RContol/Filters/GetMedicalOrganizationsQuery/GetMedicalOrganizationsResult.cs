using Core.Dtos.Filters;

namespace Application.Queries.RContol.Filters.GetMedicalOrganizationsQuery;

public sealed record GetMedicalOrganizationsResult(
    IReadOnlyCollection<MedicalOrganizationDto> MedicalOrganizations);
