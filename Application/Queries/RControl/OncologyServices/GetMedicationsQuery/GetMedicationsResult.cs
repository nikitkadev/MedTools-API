using Core.Dtos.RControl.OncologyServices;

namespace Application.Queries.RControl.OncologyServices.GetMedicationsQuery;

public sealed record GetMedicationsResult(IReadOnlyCollection<MedicationDto> Medications);
