using Core.Common.Dtos;

namespace Application.Queries.MedView.Filters.GetMedicalCareProfileFilterOptionsQuery;

public sealed record GetMedicalCareProfileFilterOptionsResult(IReadOnlyCollection<FilterOptionDto> FilterOptions);
