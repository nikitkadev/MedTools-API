using Core.Dtos.RControl.Categories.MedicalCase;

namespace Application.Queries.RContol.MedicalCases.GetDefectsQuery;

public sealed record GetDefectsResult(
    IReadOnlyCollection<DefectDto> Defects,
    int TotalCount);
