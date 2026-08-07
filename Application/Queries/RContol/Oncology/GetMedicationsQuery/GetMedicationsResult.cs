using Core.Dtos.RControl.Oncology;

namespace Application.Queries.RContol.Oncology.GetMedicationsQuery;

public sealed record GetMedicationsResult(IReadOnlyCollection<MedicationDto> Medications);
