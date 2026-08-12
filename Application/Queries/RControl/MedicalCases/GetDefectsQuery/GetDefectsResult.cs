using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RControl.MedicalCases.GetDefectsQuery;

public sealed record GetDefectsResult(
    IReadOnlyCollection<DefectDto> Defects,
    int TotalCount);
