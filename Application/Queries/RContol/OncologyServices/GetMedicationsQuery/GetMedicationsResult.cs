using Core.Dtos.RControl.OncologyServices;

namespace Application.Queries.RContol.OncologyServices.GetMedicationsQuery;

public sealed record GetMedicationsResult(IReadOnlyCollection<MedicationDto> Medications);
