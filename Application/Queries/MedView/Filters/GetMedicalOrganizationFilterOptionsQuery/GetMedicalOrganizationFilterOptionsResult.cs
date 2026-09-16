using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetMedicalOrganizationFilterOptionsQuery;

public sealed record GetMedicalOrganizationFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> Options);
