using Core.Dtos.RControl.Lookups;

namespace Application.Queries.RControl.Lookups.GetMedicalOrganizationsQuery;

public sealed record GetMedicalOrganizationsResult(IReadOnlyCollection<MedicalOrganizationDto> MedicalOrganizations);
