using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RContol.MedicalCases.GetDefectsQuery;

public sealed record GetDefectsResult(
    IReadOnlyCollection<DefectDto> Defects,
    int TotalCount);
